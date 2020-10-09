using PSoft.Libraryd.Domain.DTOs;
using PSoft.Libraryd.Domain.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PSoft.Libraryd.AcessData.Queries
{
    public class ClienteQuery : IClienteQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;
        private readonly LibrarydDbContext _dbContext;

        public ClienteQuery(IDbConnection connection, LibrarydDbContext dbContext, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this._dbContext = dbContext;
            this.sqlKataCompiler = sqlKataCompiler;
        }
        public bool ClienteExists(int ClienteId)
        {
            var query = _dbContext.Clientes.Where(c => c.ClienteId == ClienteId).FirstOrDefault();
            if (query == null) return false;
            return true;
        }

        public List<ResponseClienteDTO> GetClientes(string nombre, string apellido, string dni)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            var query = db.Query("Clientes")
                .When(!string.IsNullOrEmpty(nombre), q => q.Where("Nombre", "=", nombre))
                .When(!string.IsNullOrEmpty(apellido), q => q.Where("Apellido", "=", apellido))
                .When(!string.IsNullOrEmpty(dni), q => q.Where("DNI", "=", dni));
            var result = query.Get<ResponseClienteDTO>();
            if (!result.Any())
                throw new Exception("No se encontraron resultados.");
            return result.ToList();
        }
    }
}

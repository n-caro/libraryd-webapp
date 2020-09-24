using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SqlKata.Compilers;
using SqlKata.Execution;
using PSoft.Libraryd.Domain.Queries;
using PSoft.Libraryd.Domain.DTOs;
using System.Linq;
using Dapper;
using PSoft.Libraryd.Domain.Entities;

namespace PSoft.Libraryd.AcessData.Queries
{
    public class LibroQuery : ILibroQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;
        private readonly LibrarydDbContext _dbContext;

        public LibroQuery(IDbConnection connection, LibrarydDbContext dbContext, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this._dbContext = dbContext;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<ResponseGetAllLibroWithStock> GetAllLibroWithStock()
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Libros")
                .Where("Stock", ">", 0);
            var result = query.Get<ResponseGetAllLibroWithStock>();
            return result.ToList();
        }

        public ResponseGetLibroByISBN GetLibroByISBN(string ISBN)
        {
            var query = _dbContext.Libros.Where(l => l.ISBN == ISBN).FirstOrDefault();
            if (query == null) return null;
            return new ResponseGetLibroByISBN
            {
                Titulo = query.Titulo,
                ISBN = query.ISBN
            };
         }

        public bool LibroHasStock(string ISBN)
        {
            var query = _dbContext.Libros.Where(l => l.ISBN == ISBN).FirstOrDefault();
            if (query == null) return false ; //avoid
            if (query.Stock > 0) return true;
            return false;
        }
    }
}

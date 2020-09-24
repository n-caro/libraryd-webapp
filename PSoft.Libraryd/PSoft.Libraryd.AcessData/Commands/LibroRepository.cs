using PSoft.Libraryd.Domain.Commands;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PSoft.Libraryd.AcessData.Commands
{
    public class LibroRepository : ILibroRepository
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;
        private readonly LibrarydDbContext _dbContext;

        public LibroRepository(IDbConnection connection, LibrarydDbContext dbContext, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this._dbContext = dbContext;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public bool LibroDiscountStock(string ISBN)
        {
            var entity = _dbContext.Libros.FirstOrDefault(l => l.ISBN == ISBN);
            // Validate entity is not null
            if (entity != null)
            {
                if (entity.Stock != 0)
                {
                    entity.Stock = entity.Stock - 1;
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}

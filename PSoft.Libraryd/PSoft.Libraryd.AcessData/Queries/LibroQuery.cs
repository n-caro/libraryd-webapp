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
            var db = new QueryFactory(connection, sqlKataCompiler);
            var query = db.Query("Libros").Where("ISBN", "=", ISBN).FirstOrDefault();
            if (query == null) return false;
            return (query.Stock > 0);
        }
        public bool LibroExists(string ISBN)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            var query = db.Query("Libros").Where("ISBN", "=", ISBN).FirstOrDefault();
            if (query == null) return false;
            return true;
        }

        public List<ResponseLibroDTO> GetLibros(bool? stock, string autor, string titulo)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            var query = db.Query("Libros")
                .When(stock.HasValue && stock.Value, q => q.Where("Stock", ">", 0))
                .When(stock.HasValue && stock.Value == false, q => q.Where("Stock", "=", 0))
                .When(!string.IsNullOrEmpty(autor), q => q.WhereLike("Autor", "%"+ autor + "%"))
                .When(!string.IsNullOrEmpty(titulo), q => q.WhereLike("Titulo", "%" + titulo + "%"));
            var result = query.Get<ResponseLibroDTO>();
            if (!result.Any())
                throw new Exception("No se encontraron resultados.");
            return result.ToList();
        }
    }
}

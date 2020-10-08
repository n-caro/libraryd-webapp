using PSoft.Libraryd.Domain.DTOs;
using PSoft.Libraryd.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Application.Services
{
    public class LibroService : ILibroService
    {
        private readonly ILibroQuery _libroQuery;

        public LibroService(ILibroQuery libroQuery)
        {
            _libroQuery = libroQuery;
        }
        public List<ResponseLibroDTO> GetLibros(bool? stock, string autor, string titulo)
        {
            return _libroQuery.GetLibros(stock, autor, titulo);
        }
    }
}

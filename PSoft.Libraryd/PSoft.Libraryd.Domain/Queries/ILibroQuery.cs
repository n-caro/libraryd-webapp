using PSoft.Libraryd.Domain.DTOs;
using System.Collections.Generic;

namespace PSoft.Libraryd.Domain.Queries
{
    public interface ILibroQuery
    {
        ResponseGetLibroByISBN GetLibroByISBN(string ISBN);
        List<ResponseGetAllLibroWithStock> GetAllLibroWithStock();

        bool LibroExists(string ISBN);
        bool LibroHasStock(string ISBN);

        List<ResponseLibroDTO> GetLibros(bool? stock, string autor, string titulo);
    }
}

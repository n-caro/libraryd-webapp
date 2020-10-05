using PSoft.Libraryd.Domain.DTOs;
using System.Collections.Generic;

namespace PSoft.Libraryd.Domain.Queries
{
    public interface ILibroQuery
    {
        ResponseGetLibroByISBN GetLibroByISBN(string ISBN);
        List<ResponseGetAllLibroWithStock> GetAllLibroWithStock();

        bool LibroHasStock(string ISBN);
    }
}

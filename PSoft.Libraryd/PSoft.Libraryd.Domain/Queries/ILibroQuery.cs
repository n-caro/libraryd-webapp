using PSoft.Libraryd.Domain.DTOs;
using PSoft.Libraryd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Domain.Queries
{
    public interface ILibroQuery
    {
        ResponseGetLibroByISBN GetLibroByISBN(string ISBN);
        List<ResponseGetAllLibroWithStock> GetAllLibroWithStock();

        bool LibroHasStock(string ISBN);
    }
}

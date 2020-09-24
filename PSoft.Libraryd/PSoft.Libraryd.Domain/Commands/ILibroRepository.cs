using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Domain.Commands
{
    public interface ILibroRepository
    {
        bool LibroDiscountStock(string ISBN);
    }
}

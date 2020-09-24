using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Domain.Queries
{
    public interface IClienteQuery
    {
        bool ClienteExists(int ClienteId);
    }
}

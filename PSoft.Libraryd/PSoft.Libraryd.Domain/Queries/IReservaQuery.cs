using PSoft.Libraryd.Domain.DTOs;
using System.Collections.Generic;

namespace PSoft.Libraryd.Domain.Queries
{
    public interface IReservaQuery
    {
        List<ResponseGetAllReserva> GetAllReserva();
    }
}

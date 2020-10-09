using PSoft.Libraryd.Domain.DTOs;
using System.Collections.Generic;

namespace PSoft.Libraryd.Domain.Queries
{
    public interface IAlquilerQuery
    {
        List<ResponseAlquilerDTO> GetAlquileres(int estado);
        ResponseGetAlquileresByCliente GetByCliente(int cliente);
    }
}

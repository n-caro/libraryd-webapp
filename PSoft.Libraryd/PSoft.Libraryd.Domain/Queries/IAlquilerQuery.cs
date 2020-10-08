using PSoft.Libraryd.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Domain.Queries
{
    public interface IAlquilerQuery
    {
        List<ResponseAlquilerDTO> GetAlquileres(int estado);
        ResponseGetAlquileresByCliente GetByCliente(int cliente);
    }
}

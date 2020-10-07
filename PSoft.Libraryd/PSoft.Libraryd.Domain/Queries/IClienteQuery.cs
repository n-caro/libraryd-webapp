using PSoft.Libraryd.Domain.DTOs;
using System.Collections.Generic;

namespace PSoft.Libraryd.Domain.Queries
{
    public interface IClienteQuery
    {
        bool ClienteExists(int ClienteId);
        List<ResponseClienteDTO> GetClientes(string nombre, string apellido, string dni);
    }
}

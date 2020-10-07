using PSoft.Libraryd.Domain.DTOs;
using PSoft.Libraryd.Domain.Entities;
using System.Collections.Generic;

namespace PSoft.Libraryd.Application.Services
{
    public interface IClienteService
    {
        Cliente CreateCliente(ClienteDTO cliente);

        List<ResponseClienteDTO> GetClientes(string nombre, string apellido, string dni);
    }
}

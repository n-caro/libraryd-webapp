using PSoft.Libraryd.Domain.DTOs;
using PSoft.Libraryd.Domain.Entities;

namespace PSoft.Libraryd.Application.Services
{
    public interface IClienteService
    {
        Cliente CreateCliente(ClienteDTO cliente);
    }
}

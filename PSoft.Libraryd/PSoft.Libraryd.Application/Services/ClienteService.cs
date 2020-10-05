using PSoft.Libraryd.Domain.Commands;
using PSoft.Libraryd.Domain.DTOs;
using PSoft.Libraryd.Domain.Entities;

namespace PSoft.Libraryd.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IGenericsRepository _repository;
        public ClienteService(IGenericsRepository repository)
        {
            _repository = repository;
        }
        public Cliente CreateCliente(ClienteDTO cliente)
        {
            var entity = new Cliente
            {
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                DNI = cliente.DNI,
                Email = cliente.Email
            };
            _repository.Add<Cliente>(entity);
            return entity;
        }
    }
}

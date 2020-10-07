using PSoft.Libraryd.Domain.Commands;
using PSoft.Libraryd.Domain.DTOs;
using PSoft.Libraryd.Domain.Entities;
using System;
using System.Text.RegularExpressions;

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
            ValidateClienteDTO(cliente);
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

        private void ValidateClienteDTO(ClienteDTO cliente)
        {
            if (cliente.Nombre == "" || cliente.Apellido == "" || cliente.DNI == "" || cliente.Email == "")
                throw new ArgumentException("No se aceptan campos vacios.");
            // validateEmail
            string patternEmail = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            if(Regex.IsMatch(cliente.Email, patternEmail))
                throw new ArgumentException("No se ingreso un correo valido.");
        }

    }
}
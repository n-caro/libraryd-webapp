using PSoft.Libraryd.Domain.Commands;
using PSoft.Libraryd.Domain.DTOs;
using PSoft.Libraryd.Domain.Entities;
using PSoft.Libraryd.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PSoft.Libraryd.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IGenericsRepository _repository;
        private readonly IClienteQuery _clienteQuery;

        public ClienteService(IGenericsRepository repository, IClienteQuery clienteQuery)
        {
            _repository = repository;
            _clienteQuery = clienteQuery;
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

        public List<ResponseClienteDTO> GetAllClientes()
        {
            return _clienteQuery.GetAllCliente();
        }

        private void ValidateClienteDTO(ClienteDTO cliente)
        {
            if (cliente.Nombre == "" || cliente.Apellido == "" || cliente.DNI == "" || cliente.Email == "")
                throw new ArgumentException("No se aceptan campos vacios.");
            // validateEmail
            string patternEmail = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            if(!Regex.IsMatch(cliente.Email, patternEmail))
                throw new ArgumentException("No se ingreso un correo valido.");
        }

    }
}
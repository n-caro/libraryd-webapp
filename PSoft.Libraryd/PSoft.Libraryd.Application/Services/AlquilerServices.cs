using PSoft.Libraryd.Domain.Commands;
using PSoft.Libraryd.Domain.DTOs;
using PSoft.Libraryd.Domain.Entities;
using PSoft.Libraryd.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Application.Services
{
    public class AlquilerServices : IAlquilerServices
    {
        private readonly IGenericsRepository _repository;
        private readonly ILibroRepository _libroRepository;
        private readonly ILibroQuery _libroquery;
        private readonly IClienteQuery _clienteQuery;
        public AlquilerServices(IGenericsRepository repository, ILibroQuery libroquery, ILibroRepository libroRepository, IClienteQuery clienteQuery)
        {
            _repository = repository;
            _libroquery = libroquery;
            _libroRepository = libroRepository;
            _clienteQuery = clienteQuery;
        }
        public Alquiler CreateAlquiler(AlquilerDTO alquiler)
        {
            // Check if Libro has stock (and Exists)
            if (!_libroquery.LibroHasStock(alquiler.ISBN)) throw new ArgumentException();
            // Check if Cliente Exist
            if (!_clienteQuery.ClienteExists(alquiler.Cliente)) throw new ArgumentException();
            var entity = new Alquiler
            {
                FechaAlquiler = DateTime.Now,
                ClienteId = alquiler.Cliente,
                EstadoId = 1,
                FechaDevolucion = DateTime.Now.AddDays(7),
                ISBN = alquiler.ISBN
            };
            //save
            _repository.Add<Alquiler>(entity);
            _libroRepository.LibroDiscountStock(alquiler.ISBN);
            return entity;
        }

        public Alquiler CreateReserva(AlquilerDTO reserva)
        {
            // validate if Libro exists
            if (!_libroquery.LibroHasStock(reserva.ISBN)) throw new ArgumentException();
            // Check if Cliente Exist
            if (!_clienteQuery.ClienteExists(reserva.Cliente)) throw new ArgumentException();
            // Check if Date is valid
            if(reserva.FechaReserva < DateTime.Today) throw new ArgumentException();

            var entity = new Alquiler
            {
                FechaReserva = reserva.FechaReserva,
                ClienteId = reserva.Cliente,
                EstadoId = 2,
                ISBN = reserva.ISBN
            };
            _repository.Add<Alquiler>(entity);
            return entity;
        }
    }
}

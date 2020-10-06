using PSoft.Libraryd.Domain.Commands;
using PSoft.Libraryd.Domain.DTOs;
using PSoft.Libraryd.Domain.Entities;
using PSoft.Libraryd.Domain.Queries;
using System;

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
            ValidateAlquilerDTO(alquiler);
            var entity = new Alquiler
            {
                FechaAlquiler = DateTime.Now,
                ClienteId = alquiler.Cliente,
                EstadoId = 1,
                FechaDevolucion = DateTime.Now.AddDays(7),
                ISBN = alquiler.ISBN
            };
            _repository.Add<Alquiler>(entity);
            _libroRepository.LibroDiscountStock(alquiler.ISBN);
            return entity;
        }

        public Alquiler CreateReserva(AlquilerDTO reserva)
        {
            ValidateAlquilerDTO(reserva);
            if (reserva.FechaReserva < DateTime.Today) throw new ArgumentException("Fecha no valida");

            var entity = new Alquiler
            {
                FechaReserva = reserva.FechaReserva,
                ClienteId = reserva.Cliente,
                EstadoId = 2,
                ISBN = reserva.ISBN
            };
            _repository.Add<Alquiler>(entity);
            _libroRepository.LibroDiscountStock(reserva.ISBN);
            return entity;
        }

        private void ValidateAlquilerDTO(AlquilerDTO alquiler)
        {
            if (!_clienteQuery.ClienteExists(alquiler.Cliente)) throw new ArgumentException("Cliente no existente");
            if (!_libroquery.LibroExists(alquiler.ISBN)) throw new ArgumentException("ISBN no válido");
            if (!_libroquery.LibroHasStock(alquiler.ISBN)) throw new ArgumentException("Libro no tiene stock disponible");
        }
    }
}

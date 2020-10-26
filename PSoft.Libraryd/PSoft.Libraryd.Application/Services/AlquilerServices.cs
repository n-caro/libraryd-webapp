using PSoft.Libraryd.Domain.Commands;
using PSoft.Libraryd.Domain.DTOs;
using PSoft.Libraryd.Domain.Entities;
using PSoft.Libraryd.Domain.Queries;
using System;
using System.Collections.Generic;

namespace PSoft.Libraryd.Application.Services
{
    public class AlquilerServices : IAlquilerServices
    {
        private readonly IGenericsRepository _repository;
        private readonly ILibroRepository _libroRepository;
        private readonly ILibroQuery _libroquery;
        private readonly IClienteQuery _clienteQuery;
        private readonly IAlquilerQuery _alquilerQuery;
        private readonly IAlquilerRepository _alquilerRepository;
        public AlquilerServices(IGenericsRepository repository, ILibroQuery libroquery, ILibroRepository libroRepository, IClienteQuery clienteQuery, IAlquilerQuery alquilerQuery, IAlquilerRepository alquilerRepository)
        {
            _repository = repository;
            _libroquery = libroquery;
            _libroRepository = libroRepository;
            _clienteQuery = clienteQuery;
            _alquilerQuery = alquilerQuery;
            _alquilerRepository = alquilerRepository;
        }
        public ResponseAlquiler CreateAlquiler(AlquilerDTO alquiler)
        {
            ValidateAlquilerDTO(alquiler);
            if (alquiler.FechaAlquiler.HasValue && alquiler.FechaAlquiler.Value < DateTime.Today) throw new ArgumentException("Fecha de Alquiler no valida");
            if (!alquiler.FechaAlquiler.HasValue)
                alquiler.FechaAlquiler = DateTime.Now;
            var entity = new Alquiler
            {
                FechaAlquiler = alquiler.FechaAlquiler,
                ClienteId = alquiler.Cliente,
                EstadoId = 2,
                FechaDevolucion = DateTime.Now.AddDays(7),
                ISBN = alquiler.ISBN
            };
            _repository.Add<Alquiler>(entity);
            _libroRepository.LibroDiscountStock(alquiler.ISBN);
            return new ResponseAlquiler
            {
                Id = entity.Id,
                Cliente = entity.Cliente,
                EstadoId = entity.EstadoId,
                FechaAlquiler = entity.FechaAlquiler.Value,
                FechaDevolucion = entity.FechaDevolucion.Value,
                Libro = entity.Libro
            };
        }

        public ResponseReserva CreateReserva(AlquilerDTO reserva)
        {
            ValidateAlquilerDTO(reserva);
            if (!reserva.FechaReserva.HasValue) throw new ArgumentException("Fecha de Reserva es requerida como parametro.");
            if (reserva.FechaReserva.Value < DateTime.Today) throw new ArgumentException("Fecha de Reserva no valida.");

            var entity = new Alquiler
            {
                FechaReserva = reserva.FechaReserva,
                ClienteId = reserva.Cliente,
                EstadoId = 1,
                ISBN = reserva.ISBN
            };
            _repository.Add<Alquiler>(entity);
            _libroRepository.LibroDiscountStock(reserva.ISBN);
            return new ResponseReserva
            {
                Id = entity.Id,
                EstadoId = entity.EstadoId,
                FechaReserva = entity.FechaReserva.Value,
                Cliente = entity.Cliente,
                Libro = entity.Libro
            };
        }

        public List<ResponseAlquilerDTO> GetAlquileres(int estado)
        {
            return _alquilerQuery.GetAlquileres(estado);
        }

        public ResponseGetAlquileresByCliente GetAlquileresByCliente(int id)
        {
            return _alquilerQuery.GetByCliente(id);
        }

        public bool UpdateAlquiler(RequestAlquilerUpdate alquilerUpdate)
        {
            return _alquilerRepository.UpdateAlquiler(alquilerUpdate);
        }

        private void ValidateAlquilerDTO(AlquilerDTO alquiler)
        {
            if (!_clienteQuery.ClienteExists(alquiler.Cliente)) throw new ArgumentException("Cliente no existente");
            if (!_libroquery.LibroExists(alquiler.ISBN)) throw new ArgumentException("ISBN no válido");
            if (!_libroquery.LibroHasStock(alquiler.ISBN)) throw new ArgumentException("Libro no tiene stock disponible");
        }
    }
}

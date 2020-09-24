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
        private readonly ILibroQuery _libroquery;
        private readonly ILibroRepository _libroRepository;
        public AlquilerServices(IGenericsRepository repository, ILibroQuery libroquery, ILibroRepository libroRepository)
        {
            _repository = repository;
            _libroquery = libroquery;
            _libroRepository = libroRepository;
        }
        public Alquiler CreateAlquiler(AlquilerDTO alquiler)
        {
            // consultar libro y restar
            if (!_libroquery.LibroHasStock(alquiler.ISBN))
            {
                Console.WriteLine("EL LIBRO NO STOCK - FINALIZAR");

            }
            // create alquiler
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
            var entity = new Alquiler
            {
                FechaReserva = DateTime.Now,
                ClienteId = reserva.Cliente,
                EstadoId = 2,
                FechaDevolucion = DateTime.Now.AddDays(7),
                ISBN = reserva.ISBN
            };
            _repository.Add<Alquiler>(entity);
            return entity;
        }
    }
}

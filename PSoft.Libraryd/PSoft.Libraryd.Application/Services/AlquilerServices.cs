using PSoft.Libraryd.Domain.Commands;
using PSoft.Libraryd.Domain.DTOs;
using PSoft.Libraryd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Application.Services
{
    public class AlquilerServices : IAlquilerServices
    {
        private readonly IGenericsRepository _repository;
        public AlquilerServices(IGenericsRepository repository)
        {
            _repository = repository;
        }
        public Alquiler CreateAlquiler(AlquilerDTO alquiler)
        {
            // buscar libro
            // verificar stock
            // crear alquiler
            var entity = new Alquiler
            {
                FechaAlquiler = DateTime.Now,
                ClienteId = alquiler.Cliente,
                EstadoId = 1,
                FechaDevolucion = DateTime.Now.AddDays(7),
                ISBN = alquiler.ISBN
            };
            _repository.Add<Alquiler>(entity);
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

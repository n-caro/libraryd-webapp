﻿using PSoft.Libraryd.Domain.Entities;
using System;

namespace PSoft.Libraryd.Domain.DTOs
{
    public class ResponseAlquiler
    {
        public int Id { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public int EstadoId { get; set; }
        public Cliente Cliente { get; set; }
        public Libro Libro { get; set; }
    }
}

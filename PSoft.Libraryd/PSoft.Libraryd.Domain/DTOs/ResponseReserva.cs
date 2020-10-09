﻿using PSoft.Libraryd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Domain.DTOs
{
    public class ResponseReserva
    {
        public int Id { get; set; }
        public DateTime FechaReserva { get; set; }
        public int EstadoId { get; set; }
        public Cliente Cliente { get; set; }
        public Libro Libro { get; set; }
    }
}

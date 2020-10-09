using PSoft.Libraryd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Domain.DTOs
{
    public class ResponseAlquiler
    {
        public int Id { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public EstadoDeAlquiler Estado { get; set; }
        public Cliente Cliente { get; set; }
        public Libro Libro { get; set; }
    }
}

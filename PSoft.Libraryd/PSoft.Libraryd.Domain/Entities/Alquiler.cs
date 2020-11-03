using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSoft.Libraryd.Domain.Entities
{
    public class Alquiler
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string ISBN { get; set; }
        public int EstadoId { get; set; }
        public DateTime? FechaAlquiler { get; set; }
        public DateTime? FechaReserva { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        [ForeignKey("EstadoId")]
        public EstadoDeAlquiler EstadoDeAlquiler { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }
        [ForeignKey("ISBN")]
        public Libro Libro { get; set; }

    }
}

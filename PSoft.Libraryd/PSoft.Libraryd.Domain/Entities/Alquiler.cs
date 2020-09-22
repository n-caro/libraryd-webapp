using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Domain.Entities
{
    public class Alquiler
    {
        public int Id { get; set; }
        public int Cliente { get; set; }
        public string ISBN { get; set; }
        public int Estado { get; set; }
        public DateTime FechaAlquiler { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime FechaDevolucion { get; set; }
    }
}

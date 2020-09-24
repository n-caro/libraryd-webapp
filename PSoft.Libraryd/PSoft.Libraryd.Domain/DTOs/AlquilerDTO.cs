using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Domain.DTOs
{
    public class AlquilerDTO
    {
        public int Cliente { get; set; }
        public string ISBN { get; set; }
        public DateTime FechaReserva { get; set; }
    }
}

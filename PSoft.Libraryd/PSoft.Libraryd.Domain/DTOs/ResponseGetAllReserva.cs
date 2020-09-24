using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Domain.DTOs
{
    public class ResponseGetAllReserva
    {
        // Reserva
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaAlquiler { get; set; }
        // Libro
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public string Edicion { get; set; }
        // Cliente
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
    }
}

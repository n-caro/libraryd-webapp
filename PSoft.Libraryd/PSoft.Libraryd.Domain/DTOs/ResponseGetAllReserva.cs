using System;

namespace PSoft.Libraryd.Domain.DTOs
{
    public class ResponseGetAllReserva
    {
        // Reserva
        public int ReservaID { get; set; }
        public DateTime ReservaFecha { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteApellido { get; set; }
        public string ClienteDNI { get; set; }
        public string LibroISBN { get; set; }
        public string LibroTitulo { get; set; }
        public string LibroAutor { get; set; }
        public string LibroEdicion { get; set; }
        public string LibroEditorial { get; set; }
    }
}

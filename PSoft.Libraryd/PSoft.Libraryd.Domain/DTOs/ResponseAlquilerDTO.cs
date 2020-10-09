using System;

namespace PSoft.Libraryd.Domain.DTOs
{
    public class ResponseAlquilerDTO
    {
        public int Id { get; set; }
        public int Estado { get; set; }
        public int ClienteID { get; set; }

        public DateTime? FechaReserva { get; set; }
        public DateTime? FechaAlquiler { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        // Libro Info
        public string LibroISBN { get; set; }
        public string LibroTitulo { get; set; }
        public string LibroAutor { get; set; }
        public string LibroEdicion { get; set; }
        public string LibroEditorial { get; set; }
        public string LibroImagen { get; set; }
    }
}

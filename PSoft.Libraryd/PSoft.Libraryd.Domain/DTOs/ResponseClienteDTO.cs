using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Domain.DTOs
{
    public class ResponseClienteDTO
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
    }
}

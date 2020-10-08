using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Domain.DTOs
{
    public class ResponseGetAlquileresByCliente
    {
        public int ClienteId { get; set; }
        public List<ResponseAlquilerDTO> alquileres { get; set; }
    }
}

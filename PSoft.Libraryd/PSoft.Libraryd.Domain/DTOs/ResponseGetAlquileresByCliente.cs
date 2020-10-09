using System.Collections.Generic;

namespace PSoft.Libraryd.Domain.DTOs
{
    public class ResponseGetAlquileresByCliente
    {
        public int ClienteId { get; set; }
        public List<ResponseAlquilerDTO> alquileres { get; set; }
    }
}

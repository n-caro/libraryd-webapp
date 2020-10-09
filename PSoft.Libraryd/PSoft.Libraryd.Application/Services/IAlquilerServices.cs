using PSoft.Libraryd.Domain.DTOs;
using System.Collections.Generic;

namespace PSoft.Libraryd.Application.Services
{
    public interface IAlquilerServices
    {
        ResponseAlquiler CreateAlquiler(AlquilerDTO alquiler);
        ResponseReserva CreateReserva(AlquilerDTO reserva);

        List<ResponseAlquilerDTO> GetAlquileres(int estado);

        ResponseGetAlquileresByCliente GetAlquileresByCliente(int id);

        bool UpdateAlquiler(RequestAlquilerUpdate alquilerUpdate);
    }
}

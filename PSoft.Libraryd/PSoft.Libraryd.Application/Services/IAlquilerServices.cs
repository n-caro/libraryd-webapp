using PSoft.Libraryd.Domain.DTOs;
using PSoft.Libraryd.Domain.Entities;
using System.Collections.Generic;

namespace PSoft.Libraryd.Application.Services
{
    public interface IAlquilerServices
    {
        ResponseAlquiler CreateAlquiler(AlquilerDTO alquiler);
        Alquiler CreateReserva(AlquilerDTO reserva);

        List<ResponseAlquilerDTO> GetAlquileres(int estado);

        ResponseGetAlquileresByCliente GetAlquileresByCliente(int id);

        bool UpdateAlquiler(RequestAlquilerUpdate alquilerUpdate);
    }
}

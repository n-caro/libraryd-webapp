using PSoft.Libraryd.Domain.DTOs;
using PSoft.Libraryd.Domain.Entities;

namespace PSoft.Libraryd.Application.Services
{
    public interface IAlquilerServices
    {
        Alquiler CreateAlquiler(AlquilerDTO alquiler);
        Alquiler CreateReserva(AlquilerDTO reserva);
    }
}

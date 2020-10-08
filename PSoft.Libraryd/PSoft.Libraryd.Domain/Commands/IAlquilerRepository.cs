using PSoft.Libraryd.Domain.DTOs;

namespace PSoft.Libraryd.Domain.Commands
{
    public interface IAlquilerRepository
    {
        bool UpdateAlquiler(RequestAlquilerUpdate alquilerUpdate);
    }
}

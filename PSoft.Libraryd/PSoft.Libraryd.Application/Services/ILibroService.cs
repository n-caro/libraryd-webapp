using PSoft.Libraryd.Domain.DTOs;
using System.Collections.Generic;

namespace PSoft.Libraryd.Application.Services
{
    public interface ILibroService
    {
        List<ResponseLibroDTO> GetLibros(bool? stock, string autor, string titulo);
    }
}

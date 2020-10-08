using PSoft.Libraryd.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Application.Services
{
    public interface ILibroService
    {
        List<ResponseLibroDTO> GetLibros(bool? stock, string autor, string titulo);
    }
}

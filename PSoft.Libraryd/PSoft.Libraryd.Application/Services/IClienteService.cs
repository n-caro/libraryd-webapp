using PSoft.Libraryd.Domain.DTOs;
using PSoft.Libraryd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Application.Services
{
    public interface IClienteService
    {
        Cliente CreateCliente(ClienteDTO cliente);
    }
}

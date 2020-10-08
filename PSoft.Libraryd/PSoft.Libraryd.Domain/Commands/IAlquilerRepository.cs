using PSoft.Libraryd.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Domain.Commands
{
    public interface IAlquilerRepository
    {
        bool UpdateAlquiler(RequestAlquilerUpdate alquilerUpdate);
    }
}

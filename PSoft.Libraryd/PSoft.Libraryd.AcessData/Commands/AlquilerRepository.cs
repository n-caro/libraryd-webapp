using PSoft.Libraryd.Domain.Commands;
using PSoft.Libraryd.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSoft.Libraryd.AcessData.Commands
{
    public class AlquilerRepository : IAlquilerRepository
    {
        private readonly LibrarydDbContext _dbContext;

        public AlquilerRepository(LibrarydDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public bool UpdateAlquiler(RequestAlquilerUpdate alquilerUpdate)
        {
            var entity = _dbContext.Alquileres.FirstOrDefault(a => a.ClienteId == alquilerUpdate.cliente && a.ISBN == alquilerUpdate.ISBN && a.EstadoId == 1);
            if(entity == null) throw new Exception("Alquiler no encontrado");
            // update to Alquiler
            entity.EstadoId = 2;
            entity.FechaAlquiler = DateTime.Now;
            entity.FechaAlquiler = DateTime.Now.AddDays(7);
            _dbContext.SaveChanges();
            return true;
        }
    }
}

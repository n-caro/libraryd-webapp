using PSoft.Libraryd.Domain.DTOs;
using PSoft.Libraryd.Domain.Queries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PSoft.Libraryd.AcessData.Queries
{
    public class ReservaQuery : IReservaQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;
        private readonly LibrarydDbContext _dbContext;
        private const int ESTADO_RESERVA_ID = 2;

        public ReservaQuery(IDbConnection connection, LibrarydDbContext dbContext, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this._dbContext = dbContext;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<ResponseGetAllReserva> GetAllReserva()
        {
            /* FUNCIONA
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Alquileres")
                .Where("Estado", "=", ESTADO_RESERVA_ID)
                .Join("Clientes", "Alquileres.Cliente", "Clientes.ClienteId")
                .Join("Libros", "Alquileres.ISBN", "Libros.ISBN");

            var result = query.Get<ResponseGetAllReserva>();
            return result.ToList();
            */

            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Alquileres")
                .Select(
                    "Alquileres.Id AS ReservaID",
                    "Alquileres.FechaReserva AS ReservaFecha",
                    "Alquileres.Cliente AS ClienteID",
                    "Clientes.Nombre AS ClienteNombre",
                    "Clientes.Apellido AS ClienteApellido",
                    "Clientes.DNI AS ClienteDNI",
                    "Alquileres.ISBN AS LibroISBN",
                    "Libros.Titulo AS LibroTitulo",
                    "Libros.Autor AS LibroAutor",
                    "Libros.Edicion AS LibroEdicion",
                    "Libros.Editorial AS LibroEditorial"
                )
                .Where("Estado", "=", ESTADO_RESERVA_ID)
                .Join("Clientes", "Alquileres.Cliente", "Clientes.ClienteId")
                .Join("Libros", "Alquileres.ISBN", "Libros.ISBN");

            var result = query.Get<ResponseGetAllReserva>();
            return result.ToList();

        }

        //
    }
}

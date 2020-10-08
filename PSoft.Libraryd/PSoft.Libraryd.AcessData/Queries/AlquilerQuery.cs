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
    public class AlquilerQuery : IAlquilerQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public AlquilerQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }
        public List<ResponseAlquilerDTO> GetAlquileres(int estado)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            var query = db.Query("Alquileres")
                .Select("Alquileres.Id AS Id",
                    "Alquileres.Estado AS Estado",
                    "Alquileres.Cliente AS ClienteID",
                    "Alquileres.FechaReserva AS FechaReserva",
                    "Alquileres.FechaAlquiler AS FechaAlquiler",
                    "Alquileres.FechaDevolucion AS FechaDevolucion",
                    "Alquileres.ISBN AS LibroISBN",
                    "Libros.Titulo AS LibroTitulo",
                    "Libros.Autor AS LibroAutor",
                    "Libros.Edicion AS LibroEdicion",
                    "Libros.Editorial AS LibroEditorial",
                    "Libros.Imagen AS LibroImagen")
                // 1 = Reservado
                .When(estado == 1, q => q.Where("Estado", "=", 1))
                // 2 = Alquilado
                .When(estado == 2, q => q.Where("Estado", "=", 2))
                // 3 = Cancelado
                .When(estado == 3, q => q.Where("Estado", "=", 3))
                .Join("Libros", "Alquileres.ISBN", "Libros.ISBN");

            var result = query.Get<ResponseAlquilerDTO>(); 
            return result.ToList();
        }

        public ResponseGetAlquileresByCliente GetByCliente(int cliente)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            var alquileresResult = db.Query("Alquileres")
                .Select("Alquileres.Id AS Id",
                    "Alquileres.Estado AS Estado",
                    "Alquileres.Cliente AS ClienteID",
                    "Alquileres.FechaReserva AS FechaReserva",
                    "Alquileres.FechaAlquiler AS FechaAlquiler",
                    "Alquileres.FechaDevolucion AS FechaDevolucion",
                    "Alquileres.ISBN AS LibroISBN",
                    "Libros.Titulo AS LibroTitulo",
                    "Libros.Autor AS LibroAutor",
                    "Libros.Edicion AS LibroEdicion",
                    "Libros.Editorial AS LibroEditorial",
                    "Libros.Imagen AS LibroImagen")
                .Where("Cliente", "=", cliente)
                .Join("Libros", "Alquileres.ISBN", "Libros.ISBN")
                .Get<ResponseAlquilerDTO>()
                .ToList();

            return new ResponseGetAlquileresByCliente
            {
                ClienteId = cliente,
                alquileres = alquileresResult
            };
        }
    }
}

using PSoft.Libraryd.Application.Services;
using PSoft.Libraryd.AcessData.Commands;
using PSoft.Libraryd.AcessData;
using PSoft.Libraryd.Domain.Commands;
using PSoft.Libraryd.Domain.DTOs;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using SqlKata.Compilers;
using System.Data;
using System.Data.SqlClient;
using PSoft.Libraryd.Domain.Queries;
using PSoft.Libraryd.AcessData.Queries;

namespace PSoft.Libraryd.Presentation
{
    public class ContainerBuilder
    {
        private const string connectionString = @"Server=localhost\SQLEXPRESS;Database=LibrarydDBdevtest;Trusted_Connection=True;"; // migrate to .config file

        public static IServiceCollection Build()
        {

            IServiceCollection serviceProvider = new ServiceCollection()
                .AddDbContext<LibrarydDbContext>(options => options.UseSqlServer(connectionString))
                .AddTransient<IGenericsRepository, GenericsRepository>()
                .AddTransient<IClienteService, ClienteService>()
                .AddTransient<IAlquilerServices, AlquilerServices>()
                .AddTransient<ILibroQuery, LibroQuery>()
                .AddTransient<IReservaQuery, ReservaQuery>()
                .AddTransient<IClienteQuery, ClienteQuery>()
                .AddTransient<ILibroRepository, LibroRepository>()
                .AddTransient<Compiler, SqlServerCompiler>()
                .AddTransient<IDbConnection>(b =>{return new SqlConnection(connectionString);});
            return serviceProvider;
        }

    }
}

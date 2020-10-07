using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PSoft.Libraryd.AcessData;
using PSoft.Libraryd.AcessData.Commands;
using PSoft.Libraryd.AcessData.Queries;
using PSoft.Libraryd.Application.Services;
using PSoft.Libraryd.Domain.Commands;
using PSoft.Libraryd.Domain.Queries;
using SqlKata.Compilers;
using System.Data;
using System.Data.SqlClient;

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
                .AddTransient<IDbConnection>(b => { return new SqlConnection(connectionString); });
            return serviceProvider;
        }

    }
}

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

namespace PSoft.Libraryd.Presentation
{
    public class ContainerBuilder
    {
        private const string connectionString = @"Server=localhost\SQLEXPRESS;Database=LibrarydDBdev;Trusted_Connection=True;";

        public static IServiceCollection Build()
        {
            IServiceCollection serviceProvider = new ServiceCollection()
                .AddDbContext<LibrarydDbContext>(options => options.UseSqlServer(connectionString))
                .AddTransient<IGenericsRepository, GenericsRepository>()
                .AddTransient<IClienteService, ClienteService>()
                .AddTransient<IAlquilerServices, AlquilerServices>();
            return serviceProvider;
        }

    }
}

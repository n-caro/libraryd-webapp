using PSoft.Libraryd.Application.Services;
using PSoft.Libraryd.Domain.DTOs;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace PSoft.Libraryd.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var serviceProvider = ContainerBuilder.Build();
            var crearCliente = serviceProvider.BuildServiceProvider().GetService<IClienteService>();
            crearCliente.CreateCliente(new ClienteDTO { Nombre = "Nicolas", Apellido = "X", DNI = "45413", Email = "a" });
        }
    }
}

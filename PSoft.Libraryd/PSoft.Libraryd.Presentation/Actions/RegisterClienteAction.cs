using Microsoft.Extensions.DependencyInjection;
using PSoft.Libraryd.Application.Services;
using PSoft.Libraryd.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Presentation.Actions
{
    class RegisterClienteAction : Action
    {
        public RegisterClienteAction(IServiceCollection serviceProvider, string description)
            : base(serviceProvider, description)
        {
        }

        public override void runAction()
        {
            Console.Clear();
            Console.WriteLine(description);
            try
            {
                string nombre, apellido, dni, email;
                Console.WriteLine("Nombre: ");
                nombre = Console.ReadLine();
                Console.WriteLine("Apellido: ");
                apellido = Console.ReadLine();
                Console.WriteLine("DNI: ");
                dni = Console.ReadLine();
                Console.WriteLine("Email: ");
                email = Console.ReadLine();
                if ((nombre == "" | apellido == "" | dni == "" | email == ""))
                    throw new ArgumentNullException();
                if(!email.Contains("@"))
                    throw new ArgumentException();
                var crearCliente = _serviceProvider.BuildServiceProvider().GetService<IClienteService>();
                crearCliente.CreateCliente(new ClienteDTO { Nombre = nombre, Apellido = apellido, DNI = dni, Email = email });
                Console.WriteLine("Se ha guarado con exito el cliente.");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ha ocurrido un error: " + e.Message);
                Console.ResetColor();
            }
            finally
            {
                Console.WriteLine("Presione cualquier tecla para volver al menu principal");
                Console.ReadKey(false);
                Console.Clear();
            }
        }
    }
}

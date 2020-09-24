using Microsoft.Extensions.DependencyInjection;
using PSoft.Libraryd.Application.Services;
using PSoft.Libraryd.Domain.DTOs;
using System;

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
                if (!validateClienteFields(nombre, apellido, dni, email))
                    throw new ArgumentException();
                var crearCliente = _serviceProvider.BuildServiceProvider().GetService<IClienteService>();
                crearCliente.CreateCliente(new ClienteDTO { Nombre = nombre, Apellido = apellido, DNI = dni, Email = email });
                OutputColors.Sucess("El cliente ha sido registrado con exito.");
            }
            catch (Exception e)
            {
                OutputColors.Error("Ha ocurrido un error: " + e.Message);
            }
            finally
            {
                Console.WriteLine("\n Presione cualquier tecla para volver al menu principal");
                Console.ReadKey(false);
                Console.Clear();
            }
        }
        private static bool validateClienteFields(string nombre, string apellido, string dni, string email)
        {
            if ((nombre == "" | apellido == "" | dni == "" | email == ""))
                return false;
            return ValidatorActionFields.validateEmail(email);
        }
    }
}

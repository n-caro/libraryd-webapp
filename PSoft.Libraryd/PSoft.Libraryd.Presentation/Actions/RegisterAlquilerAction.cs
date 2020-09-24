using Microsoft.Extensions.DependencyInjection;
using PSoft.Libraryd.Application.Services;
using PSoft.Libraryd.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Presentation.Actions
{
    class RegisterAlquilerAction : Action
    {
        public RegisterAlquilerAction(IServiceCollection serviceProvider, string description)
            : base(serviceProvider, description)
        {
        }

        public override void runAction()
        {
            Console.Clear();
            Console.WriteLine(description);
            try
            {
                string isbn;
                int idcliente;
                Console.WriteLine("Cliente ID: ");
                idcliente = int.TryParse(Console.ReadLine(), out idcliente) ? idcliente : -1;
                if (idcliente <= 0) throw new ArgumentException();
                Console.WriteLine("ISBN del libro: ");
                isbn = Console.ReadLine();
                if (isbn == "") throw new ArgumentNullException();
                var createAlquiler = _serviceProvider.BuildServiceProvider().GetService<IAlquilerServices>();
                createAlquiler.CreateAlquiler(new AlquilerDTO { Cliente = idcliente, ISBN = isbn });
                Console.WriteLine("Se ha guardado con éxito el alquiler.");
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

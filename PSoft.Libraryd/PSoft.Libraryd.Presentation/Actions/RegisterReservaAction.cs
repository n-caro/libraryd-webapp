using Microsoft.Extensions.DependencyInjection;
using PSoft.Libraryd.Application.Services;
using PSoft.Libraryd.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Presentation.Actions
{
    class RegisterReservaAction : Action
    {
        public RegisterReservaAction(IServiceCollection serviceProvider, string description)
            : base(serviceProvider, description)
        {
        }

        public override void runAction()
        {
            Console.Clear();
            Console.WriteLine(description);
            try
            {
                Console.WriteLine("Cliente ID: ");
                int idcliente = int.TryParse(Console.ReadLine(), out idcliente) ? idcliente : -1;
                if (idcliente <= 0) throw new ArgumentException();
                Console.WriteLine("ISBN del libro: ");
                string isbn = Console.ReadLine();
                if (isbn == "") throw new ArgumentNullException();
                Console.WriteLine("Fecha de reserva: ");
                DateTime fechaReserva = DateTime.TryParse(Console.ReadLine(), out fechaReserva) ? fechaReserva : DateTime.MinValue;
                if(fechaReserva == DateTime.MinValue) throw new ArgumentException();
                var createAlquiler = _serviceProvider.BuildServiceProvider().GetService<IAlquilerServices>();
                createAlquiler.CreateReserva(new AlquilerDTO { Cliente = idcliente, ISBN = isbn, FechaReserva = fechaReserva });
                Console.WriteLine("Se ha guardado con éxito la reserva.");
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

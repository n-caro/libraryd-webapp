using PSoft.Libraryd.Application.Services;
using PSoft.Libraryd.Domain.DTOs;
using System;

namespace PSoft.Libraryd.Presentation.Actions
{
    class RegisterReservaAction : Action
    {
        private IAlquilerServices alquilerService;
        public RegisterReservaAction(IAlquilerServices alquilerService, string description) : base(description)
        {
            this.alquilerService = alquilerService;
        }

        public override void runAction()
        {
            Console.Clear();
            Console.WriteLine(description);
            try
            {
                Console.WriteLine("ISBN del libro: ");
                string isbn = Console.ReadLine();
                Console.WriteLine("Cliente ID: ");
                int idcliente = int.TryParse(Console.ReadLine(), out idcliente) ? idcliente : -1;
                Console.WriteLine("Fecha de reserva: ");
                DateTime fechaReserva = DateTime.TryParse(Console.ReadLine(), out fechaReserva) ? fechaReserva : DateTime.MinValue;
                alquilerService.CreateReserva(new AlquilerDTO { Cliente = idcliente, ISBN = isbn, FechaReserva = fechaReserva });
                OutputColors.Sucess("La reserva ha sido registrado con exito.");
            }
            catch (Exception e)
            {
                OutputColors.Error("Ha ocurrido un error: " + e.Message);
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

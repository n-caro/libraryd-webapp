using PSoft.Libraryd.Application.Services;
using PSoft.Libraryd.Domain.DTOs;
using System;

namespace PSoft.Libraryd.Presentation.Actions
{
    class RegisterAlquilerAction : Action
    {
        private IAlquilerServices alquilerService;
        public RegisterAlquilerAction(IAlquilerServices alquilerService, string description) : base(description)
        {
            this.alquilerService = alquilerService;
        }

        public override void runAction()
        {
            Console.Clear();
            Console.WriteLine(description);
            try
            {
                Console.WriteLine("Cliente ID: ");
                int idcliente = int.TryParse(Console.ReadLine(), out idcliente) ? idcliente : -1;
                Console.WriteLine("ISBN del libro: ");
                string isbn = Console.ReadLine();
                alquilerService.CreateAlquiler(new AlquilerDTO { Cliente = idcliente, ISBN = isbn });
                OutputColors.Sucess("Se ha registrado el alquiler con éxito.");
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

using PSoft.Libraryd.Application.Services;
using PSoft.Libraryd.Domain.DTOs;
using System;

namespace PSoft.Libraryd.Presentation.Actions
{
    class RegisterClienteAction : Action
    {
        private IClienteService clienteservice;
        public RegisterClienteAction(IClienteService clienteservice, string description) : base(description)
        {
            this.clienteservice = clienteservice;
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
                clienteservice.CreateCliente(new ClienteDTO { Nombre = nombre, Apellido = apellido, DNI = dni, Email = email });
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
    }
}

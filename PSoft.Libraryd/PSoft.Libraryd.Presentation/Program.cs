using PSoft.Libraryd.Application.Services;
using PSoft.Libraryd.Domain.DTOs;
using System;
using Microsoft.Extensions.DependencyInjection;
using PSoft.Libraryd.Domain.Queries;
using System.Collections.Generic;
using PSoft.Libraryd.Presentation.Actions;

namespace PSoft.Libraryd.Presentation
{
    class Program
    {
        public static readonly IServiceCollection serviceProvider = ContainerBuilder.Build();
        static void Main(string[] args)
        {
            // MENU
            ConsoleKeyInfo keypresed;
            IAction action;
                do
                {
                    Console.WriteLine("1. Registrar Cliente");
                    Console.WriteLine("2. Registrar Alquiler");
                    Console.WriteLine("3. Registrar Reserva");
                    Console.WriteLine("4. Enlistar Reservas");
                    Console.WriteLine("5. enlistar libros con stock");
                    Console.WriteLine("Ingrese una opción o Presione (ESC) para finalizar el programa.");
                    keypresed = Console.ReadKey(true); // show the key as you read it
                    switch (keypresed.KeyChar)
                    {
                        case '1':
                            action = new RegisterClienteAction(serviceProvider, "Registrar cliente");
                            action.runAction();
                            break;
                        case '2':
                            action = new RegisterAlquilerAction(serviceProvider, "Registrar Alquiler");
                            action.runAction();
                            break;
                        case '3':
                            action = new RegisterReservaAction(serviceProvider, "Registrar Reserva");
                            action.runAction();
                            break;

                        case '4':
                            action = new ListAllReservaAction(serviceProvider, "Enlistar eservas");
                            action.runAction();
                            break;
                        case '5':
                            action = new ListAllLibrosWithStock(serviceProvider, "Enlistar libros disponibles");
                            action.runAction();
                        break;
                        default:
                            Console.Clear();
                        break;
                    }
                }
                while (keypresed.Key != ConsoleKey.Escape);
            
        }
    }
}

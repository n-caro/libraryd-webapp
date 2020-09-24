using System;
using Microsoft.Extensions.DependencyInjection;
using PSoft.Libraryd.Presentation.Actions;

namespace PSoft.Libraryd.Presentation
{
    class Program
    {
        public static readonly IServiceCollection serviceProvider = ContainerBuilder.Build();
        static void Main(string[] args)
        {
            int option;
            // Actions Menu
            IAction[] ActionsList = new IAction[]
            {
                new RegisterClienteAction(serviceProvider, "Registrar cliente"),
                new RegisterAlquilerAction(serviceProvider, "Registrar Alquiler"),
                new RegisterReservaAction(serviceProvider, "Registrar Reserva"),
                new ListAllReservaAction(serviceProvider, "Enlistar Reservas"),
                new ListAllLibrosWithStock(serviceProvider, "Enlistar libros disponibles")
            };
            while(true)
            {
                for (int pos = 0; pos < ActionsList.Length; pos++)
                    Console.WriteLine("{0}. {1}", pos + 1, ActionsList[pos].getDescription());
                option = int.TryParse(Console.ReadLine(), out option) ? option : -1;
                if (option <= ActionsList.Length & option > 0)
                    ActionsList[option - 1].runAction();
                else
                    Console.Clear();
            }
        }
    }
}

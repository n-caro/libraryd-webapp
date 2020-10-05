using System;
using Microsoft.Extensions.DependencyInjection;
using PSoft.Libraryd.Application.Services;
using PSoft.Libraryd.Domain.Queries;
using PSoft.Libraryd.Presentation.Actions;
using SqlKata;

namespace PSoft.Libraryd.Presentation
{
    class Program
    { 
        public const string NAME = "Librayd"; // migrate to .config file
        public const string VERSION = "v1.0"; // migrate to .config file
        public const string CLIENT = "Municipalidad de Carmen de Areco"; // migrate to .config file
        public static readonly IServiceCollection serviceProvider = ContainerBuilder.Build();
        static void Main(string[] args)
        {
            int option;
            // Actions Menu
            IAction[] ActionsList = new IAction[]
            {
                new RegisterClienteAction(serviceProvider.BuildServiceProvider().GetService<IClienteService>(), "Registrar Cliente"),
                new RegisterAlquilerAction(serviceProvider.BuildServiceProvider().GetService<IAlquilerServices>(), "Registrar Alquiler"),
                new RegisterReservaAction(serviceProvider.BuildServiceProvider().GetService<IAlquilerServices>(), "Registrar Reserva"),
                new ListAllReservaAction(serviceProvider.BuildServiceProvider().GetService<IReservaQuery>(), "Enlistar reservas"),
                new ListAllLibrosWithStock(serviceProvider.BuildServiceProvider().GetService<ILibroQuery>(), "Enlistar libros disponibles")
            };
            while(true)
            {
                PrintTitle();
                OutputColors.ColorGray("MENU -------------------------------eu-------");
                for (int pos = 0; pos < ActionsList.Length; pos++)
                    Console.WriteLine("     {0}. {1}", pos + 1, ActionsList[pos].getDescription());
                OutputColors.ColorGray("-------------------------------------------");
                Console.Write("Seleccionar una opción: ");
                option = int.TryParse(Console.ReadLine(), out option) ? option : -1;
                if (option <= ActionsList.Length & option > 0)
                    ActionsList[option - 1].runAction();
                else
                    Console.Clear();
            }
        }

        private static void PrintTitle()
        {
            OutputColors.ColorBlue(NAME + " " + "version: " + VERSION);
            OutputColors.ColorGray(CLIENT);
            Console.WriteLine();
        }
    }
}

using System;
using Microsoft.Extensions.DependencyInjection;
using PSoft.Libraryd.Presentation.Actions;
using SqlKata;

namespace PSoft.Libraryd.Presentation
{
    class Program
    {
        public const string NAME = "Librayd";
        public const string VERSION = "v1.0";
        public const string CLIENT = "Municipalidad de Carmen de Areco";
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
                PrintTitle();
                OutputColors.ColorGray("MENU --------------------------------------");
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

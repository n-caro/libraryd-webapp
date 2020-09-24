using Microsoft.Extensions.DependencyInjection;
using PSoft.Libraryd.Application.Services;
using PSoft.Libraryd.Domain.DTOs;
using PSoft.Libraryd.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Presentation.Actions
{
    class ListAllLibrosWithStock : Action
    {
        public ListAllLibrosWithStock(IServiceCollection serviceProvider, string description)
            : base(serviceProvider, description)
        {
        }

        public override void runAction()
        {
            Console.Clear();
            Console.WriteLine(description);
            try
            {
                var reservaQuery = _serviceProvider.BuildServiceProvider().GetService<ILibroQuery>();
                var resultLibrosDisponibles = reservaQuery.GetAllLibroWithStock();
                if (resultLibrosDisponibles.Count == 0)
                {
                    Console.WriteLine("No hay libros disponibles.");
                }
                else
                {
                    foreach (var libro in resultLibrosDisponibles)
                    {
                        printLibro(libro);
                    }
                }
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

        private void printLibro(ResponseGetAllLibroWithStock libro)
        {
            Console.WriteLine("Titulo: {0}", libro.Titulo);
            Console.WriteLine("Autor: {0}", libro.Autor);
            Console.WriteLine("ISBN: {0}", libro.ISBN);
            Console.WriteLine("Edicion: {0}", libro.Edicion);
            Console.WriteLine("Editorial: {0}", libro.Editorial);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Stock disponible: {0}", libro.Stock);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("---------------------------------------------------------------");
            Console.ResetColor();
        }
    }
}

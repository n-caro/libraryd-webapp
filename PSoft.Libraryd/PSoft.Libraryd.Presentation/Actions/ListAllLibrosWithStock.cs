using Microsoft.Extensions.DependencyInjection;
using PSoft.Libraryd.Domain.DTOs;
using PSoft.Libraryd.Domain.Queries;
using System;

namespace PSoft.Libraryd.Presentation.Actions
{
    class ListAllLibrosWithStock : Action
    {
        private ILibroQuery reservaQuery;
        public ListAllLibrosWithStock(ILibroQuery reservaQuery, string description) :base(description)
        {
            this.reservaQuery = reservaQuery;
        }

        public override void runAction()
        {
            Console.Clear();
            Console.WriteLine(description);
            try
            {
                var resultLibrosDisponibles = reservaQuery.GetAllLibroWithStock();
                if (resultLibrosDisponibles.Count == 0)
                {
                    OutputColors.Warning("\n No hay libros disponibles. \n");
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
                OutputColors.Error("Ha ocurrido un error: " + e.Message);
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
            OutputColors.ColorGray("---------------------------------------------------------------");
            Console.WriteLine("ISBN:        {0}", libro.ISBN);
            Console.WriteLine("Titulo:      {0}", libro.Titulo);
            Console.WriteLine("Autor:       {0}", libro.Autor);
            Console.WriteLine("Edicion:     {0}", libro.Edicion);
            Console.WriteLine("Editorial:   {0}", libro.Editorial);
            OutputColors.ColorYellow("Stock:       " + libro.Stock);
            OutputColors.ColorGray("---------------------------------------------------------------");
        }
    }
}

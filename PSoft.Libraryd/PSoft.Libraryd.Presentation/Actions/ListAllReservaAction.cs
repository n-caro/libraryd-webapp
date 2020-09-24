using Microsoft.Extensions.DependencyInjection;
using PSoft.Libraryd.Application.Services;
using PSoft.Libraryd.Domain.DTOs;
using PSoft.Libraryd.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.Presentation.Actions
{
    class ListAllReservaAction : Action
    {
        public ListAllReservaAction(IServiceCollection serviceProvider, string description)
            : base(serviceProvider, description)
        {
        }

        public override void runAction()
        {
            Console.Clear();
            Console.WriteLine(description);
            try
            {
                var reservaQuery = _serviceProvider.BuildServiceProvider().GetService<IReservaQuery>();
                var resultsreservas = reservaQuery.GetAllReserva();
                if (resultsreservas.Count == 0)
                {
                    Console.WriteLine("No hay reservas actualmente.");
                }
                else
                {
                    foreach(var reserva in resultsreservas)
                    {
                        printReserva(reserva);
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

        private void printReserva(ResponseGetAllReserva reserva)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("RESERVA ID: {0} - Fecha de reserva: {1}/{2}/{3}", reserva.ReservaID, reserva.ReservaFecha.Day, reserva.ReservaFecha.Month, reserva.ReservaFecha.Year);
            Console.ResetColor();
            Console.WriteLine("Datos del cliente");
            Console.WriteLine("     ID: {0} - DNI: {1}", reserva.ClienteId, reserva.ClienteDNI);
            Console.WriteLine("Datos del libro");
            Console.WriteLine("     TITULO: {0} - Autor: {1}", reserva.LibroTitulo, reserva.LibroAutor);
            Console.WriteLine("     EDICION: {0} - Editorial: {1}", reserva.LibroEdicion, reserva.LibroEditorial);
            Console.WriteLine("     ISBN: {0}", reserva.LibroISBN);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("---------------------------------------------------------------");
            Console.ResetColor();
        }
    }
}

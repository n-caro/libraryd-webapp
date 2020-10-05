using PSoft.Libraryd.Domain.DTOs;
using PSoft.Libraryd.Domain.Queries;
using System;

namespace PSoft.Libraryd.Presentation.Actions
{
    class ListAllReservaAction : Action
    {
        private IReservaQuery reservaQuery;
        public ListAllReservaAction(IReservaQuery reservaQuery, string description) : base(description)
        {
            this.reservaQuery = reservaQuery;
        }

        public override void runAction()
        {
            Console.Clear();
            Console.WriteLine(description);
            try
            {
                var resultsreservas = reservaQuery.GetAllReserva();
                if (resultsreservas.Count == 0)
                {
                    OutputColors.Warning("\n No hay reservas actualmente.");
                }
                else
                {
                    foreach (var reserva in resultsreservas)
                    {
                        printReserva(reserva);
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

        private void printReserva(ResponseGetAllReserva reserva)
        {
            OutputColors.ColorGray("---------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("RESERVA ID: {0} - Fecha de reserva: {1}/{2}/{3}", reserva.ReservaID, reserva.ReservaFecha.Day, reserva.ReservaFecha.Month, reserva.ReservaFecha.Year);
            OutputColors.ColorGray("Datos del cliente");
            Console.WriteLine("     ID: {0} - DNI: {1}", reserva.ClienteId, reserva.ClienteDNI);
            OutputColors.ColorGray("Datos del libro");
            Console.WriteLine("     TITULO: {0} - Autor: {1}", reserva.LibroTitulo, reserva.LibroAutor);
            Console.WriteLine("     EDICION: {0} - Editorial: {1}", reserva.LibroEdicion, reserva.LibroEditorial);
            Console.WriteLine("     ISBN: {0}", reserva.LibroISBN);
            OutputColors.ColorGray("---------------------------------------------------------------");
        }
    }
}

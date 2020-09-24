using PSoft.Libraryd.Application.Services;
using PSoft.Libraryd.Domain.DTOs;
using System;
using Microsoft.Extensions.DependencyInjection;
using PSoft.Libraryd.Domain.Queries;

namespace PSoft.Libraryd.Presentation
{
    class Program
    {
        public static readonly IServiceCollection serviceProvider = ContainerBuilder.Build();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // MENU
            ConsoleKeyInfo keypresed;
            do
            {
                Console.WriteLine("1. Registrar cliente");
                Console.WriteLine("2. Registrar alquiler");
                Console.WriteLine("3. Registrar reserva");
                Console.WriteLine("4. Retornar libro por ISBN");
                Console.WriteLine("5. Enlistar libros con stock");
                Console.WriteLine("6. Enlistar reservas");
                keypresed = Console.ReadKey(true); // show the key as you read it
                switch (keypresed.KeyChar)
                {
                    case '1':
                        Console.WriteLine("+ Agregar cliente");
                        addClientOption();
                        Console.WriteLine("fin menu 1");
                        break;
                    case '2':
                        Console.WriteLine("+ Agregar alquiler");
                        addAlquiler();
                        Console.WriteLine("fin menu 2");
                        break;
                    case '3':
                        Console.WriteLine("+ Agregar reserva");
                        addReserva();
                        Console.WriteLine("fin menu 3");
                        break;
                    case '4':
                        Console.WriteLine("ISBN:");
                        string isbn = Console.ReadLine();
                        var libroQuery = serviceProvider.BuildServiceProvider().GetService<ILibroQuery>();
                        var result = libroQuery.GetLibroByISBN(isbn);
                        if(result == null)
                        {
                            Console.WriteLine("no se encontró");
                        }
                        else
                        {
                            Console.WriteLine("Resultado:");
                            Console.WriteLine(result.ISBN + result.Titulo);
                        }
                        break;
                    case '5':
                        var libroQuery2 = serviceProvider.BuildServiceProvider().GetService<ILibroQuery>();
                        var results = libroQuery2.GetAllLibroWithStock();
                        foreach(var libro in results)
                        {
                            Console.WriteLine(libro.Titulo + "STOCK: " + libro.Stock);
                        }
                        break;
                    case '6':
                        var reservaQuery = serviceProvider.BuildServiceProvider().GetService<IReservaQuery>();
                        var resultsreserva = reservaQuery.GetAllReserva();
                        foreach (var reserva in resultsreserva)
                        {
                            Console.WriteLine("RESERVA ID: {0} - Fecha de reserva: {1}", reserva.ReservaID, reserva.ReservaFecha);
                            Console.WriteLine("LIBRO");
                            Console.WriteLine("ISBN: {0}", reserva.LibroISBN);
                            Console.WriteLine("Titulo: {0} - Autor: {1}", reserva.LibroTitulo, reserva.LibroAutor);
                            Console.WriteLine("Cliente: ID: {0} - DNI: {1}", reserva.ClienteId, reserva.ClienteDNI);
                            // Libro data
                            //Console.WriteLine("     Titulo: {0}  Autor: {1}", resultado.Titulo, resultado.Autor);
                            // Client Data

                        }
                        break;
                }
            }
            while (keypresed.Key != ConsoleKey.Escape);
        }

        // addclient
        public static void addClientOption()
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
            //convierto a dto
            var crearCliente = serviceProvider.BuildServiceProvider().GetService<IClienteService>();
            crearCliente.CreateCliente(new ClienteDTO { Nombre = nombre, Apellido = apellido, DNI = dni, Email = email });
            Console.WriteLine("Se ha guardado con éxito el cliente: " +
                "\n Nombre y apellido: {0}  {1}" +
                "\n DNI: {2}  - Email: {3}", nombre, apellido, dni, email);
        }

        public static void addAlquiler()
        {
            int idcliente;
            string isbn;
            Console.WriteLine("ID del cliente: ");
            idcliente = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ISBN del libro: ");
            isbn = Console.ReadLine();
            //convierto a dto
            var createAlquiler = serviceProvider.BuildServiceProvider().GetService<IAlquilerServices>();
            createAlquiler.CreateAlquiler(new AlquilerDTO { Cliente= idcliente, ISBN = isbn });
            Console.WriteLine("Se ha guardado con éxito el alquiler: ");
        }
        public static void addReserva()
        {
            int idcliente;
            string isbn;
            Console.WriteLine("ID del cliente: ");
            idcliente = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ISBN del libro: ");
            isbn = Console.ReadLine();
            //convierto a dto
            var createAlquiler = serviceProvider.BuildServiceProvider().GetService<IAlquilerServices>();
            createAlquiler.CreateReserva(new AlquilerDTO { Cliente = idcliente, ISBN = isbn });
            Console.WriteLine("Se ha guardado con éxito la reserva: ");
        }
    }
}

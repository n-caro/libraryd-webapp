using PSoft.Libraryd.Application.Services;
using PSoft.Libraryd.Domain.DTOs;
using System;
using Microsoft.Extensions.DependencyInjection;

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

﻿using Microsoft.Extensions.DependencyInjection;
using PSoft.Libraryd.Application.Services;
using PSoft.Libraryd.Domain.DTOs;
using System;

namespace PSoft.Libraryd.Presentation.Actions
{
    class RegisterAlquilerAction : Action
    {
        public RegisterAlquilerAction(IServiceCollection serviceProvider, string description)
            : base(serviceProvider, description)
        {
        }

        public override void runAction()
        {
            Console.Clear();
            Console.WriteLine(description);
            try
            {
                Console.WriteLine("Cliente ID: ");
                int idcliente = int.TryParse(Console.ReadLine(), out idcliente) ? idcliente : -1;
                Console.WriteLine("ISBN del libro: ");
                string isbn = Console.ReadLine();
                if (!validateAlquilerFields(isbn, idcliente))
                    throw new ArgumentException();
                var createAlquiler = _serviceProvider.BuildServiceProvider().GetService<IAlquilerServices>();
                createAlquiler.CreateAlquiler(new AlquilerDTO { Cliente = idcliente, ISBN = isbn });
                OutputColors.Sucess("Se ha registrado el alquiler con éxito.");
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
        private static bool validateAlquilerFields(string isbn, int idcliente)
        {
            if (isbn == "" || idcliente <= 0)
                return false;
            return true;
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
using PSoft.Libraryd.Domain.Entities;
using PSoft.Libraryd.AcessData.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.AcessData
{
    public class LibrarydDbContext : DbContext
    {
        public DbSet<EstadoDeAlquiler> EstadoDeAlquileres { get; set; }
        public DbSet<Alquiler> Alquileres { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Libro> Libros { get; set; }

        public LibrarydDbContext(DbContextOptions<LibrarydDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new AlquilerConfiguration());
            modelBuilder.ApplyConfiguration(new EstadoDeAlquilerConfiguration());
            modelBuilder.ApplyConfiguration(new LibroConfiguration());
        }
    }
}

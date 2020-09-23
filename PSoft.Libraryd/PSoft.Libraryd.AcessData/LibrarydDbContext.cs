﻿using Microsoft.EntityFrameworkCore;
using PSoft.Libraryd.Domain.Entities;
using PSoft.Libraryd.AcessData.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.AcessData
{
    class LibrarydDbContext : DbContext
    {
        public DbSet<EstadoDeAlquiler> EstadoDeAlquileres { get; set; }
        public DbSet<Alquiler> Alquileres { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Libro> Libros { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=LibrarydDBdev;Trusted_Connection=True;");
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
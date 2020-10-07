﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PSoft.Libraryd.AcessData;

namespace PSoft.Libraryd.AcessData.Migrations
{
    [DbContext(typeof(LibrarydDbContext))]
    partial class LibrarydDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PSoft.Libraryd.Domain.Entities.Alquiler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnName("Cliente")
                        .HasColumnType("int");

                    b.Property<int>("EstadoId")
                        .HasColumnName("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaAlquiler")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("FechaDevolucion")
                        .HasColumnType("Date");

                    b.Property<DateTime?>("FechaReserva")
                        .HasColumnType("Date");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LibroISBN")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("LibroISBN");

                    b.ToTable("Alquileres");
                });

            modelBuilder.Entity("PSoft.Libraryd.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.HasKey("ClienteId");

                    b.HasAlternateKey("DNI", "Email");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("PSoft.Libraryd.Domain.Entities.EstadoDeAlquiler", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.HasKey("EstadoId");

                    b.ToTable("EstadoDeAlquileres");

                    b.HasData(
                        new
                        {
                            EstadoId = 1,
                            Descripcion = "Reservado"
                        },
                        new
                        {
                            EstadoId = 2,
                            Descripcion = "Alquilado"
                        },
                        new
                        {
                            EstadoId = 3,
                            Descripcion = "Cancelado"
                        });
                });

            modelBuilder.Entity("PSoft.Libraryd.Domain.Entities.Libro", b =>
                {
                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Edicion")
                        .IsRequired()
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Editorial")
                        .IsRequired()
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.Property<int?>("Stock")
                        .HasColumnType("int")
                        .HasMaxLength(45);

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(45)")
                        .HasMaxLength(45);

                    b.HasKey("ISBN");

                    b.ToTable("Libros");

                    b.HasData(
                        new
                        {
                            ISBN = "9783642191756",
                            Autor = "Ian Gorton",
                            Edicion = "Second Edition",
                            Editorial = "Springer",
                            Imagen = "",
                            Stock = 5,
                            Titulo = "Essential Software Architecture"
                        },
                        new
                        {
                            ISBN = "9780136073734",
                            Autor = "William Stallings",
                            Edicion = "Septima Edicion",
                            Editorial = "Pearsons",
                            Imagen = "",
                            Stock = 8,
                            Titulo = "Organización y Arquitectura de Computadores"
                        },
                        new
                        {
                            ISBN = "9780764508141",
                            Autor = "Davis, Stephen R",
                            Edicion = "2001",
                            Editorial = "Hungry Minds Inc",
                            Imagen = "",
                            Stock = 2,
                            Titulo = "C# for Dummies"
                        },
                        new
                        {
                            ISBN = "9789875809659",
                            Autor = "Dross Rotzank",
                            Edicion = "2019",
                            Editorial = "BOOKET",
                            Imagen = "",
                            Stock = 1,
                            Titulo = "Luna de Pluton"
                        },
                        new
                        {
                            ISBN = "9788497598637",
                            Autor = "Eduard Estivill",
                            Edicion = "2003",
                            Editorial = "DEBOLSILLO",
                            Imagen = "",
                            Stock = 15,
                            Titulo = "NECESITO DORMIR!"
                        },
                        new
                        {
                            ISBN = "9786073206037",
                            Autor = "Ian Sommerville",
                            Edicion = "Novena Edicion",
                            Editorial = "Addison-Wesley",
                            Imagen = "",
                            Stock = 3,
                            Titulo = "Ingenieria de Software"
                        });
                });

            modelBuilder.Entity("PSoft.Libraryd.Domain.Entities.Alquiler", b =>
                {
                    b.HasOne("PSoft.Libraryd.Domain.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PSoft.Libraryd.Domain.Entities.EstadoDeAlquiler", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PSoft.Libraryd.Domain.Entities.Libro", "Libro")
                        .WithMany()
                        .HasForeignKey("LibroISBN");
                });
#pragma warning restore 612, 618
        }
    }
}

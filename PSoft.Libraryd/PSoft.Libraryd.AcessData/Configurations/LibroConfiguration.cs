using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSoft.Libraryd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.AcessData.Configurations
{
    class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.HasKey(o => o.ISBN);
            builder.Property(s => s.ISBN)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(s => s.Titulo)
                .IsRequired()
                .HasMaxLength(45);
            builder.Property(s => s.Autor)
                .IsRequired()
                .HasMaxLength(45);
            builder.Property(s => s.Editorial)
                .IsRequired()
                .HasMaxLength(45);
            builder.Property(s => s.Edicion)
                .IsRequired()
                .HasMaxLength(45);
            builder.Property(s => s.Stock)
               .IsRequired(false)
               .HasMaxLength(45);
            builder.Property(s => s.Imagen)
               .IsRequired()
               .HasMaxLength(45);

            // PRELOAD DATA: Libros
            builder.HasData(
                new Libro {
                    Autor = "Ian Gorton",
                    Edicion = "Second Edition",
                    Editorial = "Springer",
                    Imagen = "",
                    ISBN = "9783642191756",
                    Stock = 5,
                    Titulo = "Essential Software Architecture"
                },
                new Libro
                {
                    Autor = "William Stallings",
                    Edicion = "Septima Edicion",
                    Editorial = "Pearsons",
                    Imagen = "",
                    ISBN = "9780136073734",
                    Stock = 8,
                    Titulo = "Organización y Arquitectura de Computadores"
                },
                new Libro {
                    Autor= "Davis, Stephen R",
                    Edicion = "2001",
                    Editorial = "Hungry Minds Inc",
                    Imagen = "",
                    ISBN = "9780764508141",
                    Stock = 2,
                    Titulo= "C# for Dummies"
                },
                new Libro
                {
                    Autor = "Dross Rotzank",
                    Edicion = "2019",
                    Editorial = "BOOKET",
                    Imagen = "",
                    ISBN = "9789875809659",
                    Stock = 1,
                    Titulo = "Luna de Pluton"
                },
                 new Libro
                 {
                     Autor = "Eduard Estivill",
                     Edicion = "2003",
                     Editorial = "DEBOLSILLO",
                     Imagen = "",
                     ISBN = "9788497598637",
                     Stock = 15,
                     Titulo = "NECESITO DORMIR!"
                 },
                new Libro
                {
                    Autor = "Ian Sommerville",
                    Edicion = "Novena Edicion",
                    Editorial = "Addison-Wesley",
                    Imagen = "",
                    ISBN = "9786073206037",
                    Stock = 3,
                    Titulo = "Ingenieria de Software"
                }
            );

        }

    }
}

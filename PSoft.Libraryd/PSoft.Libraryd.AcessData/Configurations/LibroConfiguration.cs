using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSoft.Libraryd.Domain.Entities;

namespace PSoft.Libraryd.AcessData.Configurations
{
    public class LibroConfiguration : IEntityTypeConfiguration<Libro>
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
				new Libro
				{
					Autor = "Ian Gorton",
					Edicion = "Second Edition",
					Editorial = "Springer",
					Imagen = "https://i.imgur.com/wVXlZzF.jpg",
					ISBN = "9783642191756",
					Stock = 5,
					Titulo = "Essential Software Architecture"
				},
				new Libro
				{
					Autor = "Ian Sommerville",
					Edicion = "Novena Edicion",
					Editorial = "Addison-Wesley",
					Imagen = "https://i.imgur.com/XwTsnyv.jpg",
					ISBN = "9786073206037",
					Stock = 4,
					Titulo = "Ingenieria de Software"
				},
				new Libro
				{
					Autor = "William Stallings",
					Edicion = "Septima Edicion",
					Editorial = "Pearsons",
					Imagen = "https://i.imgur.com/eFiruFW.jpg",
					ISBN = "9780136073734",
					Stock = 8,
					Titulo = "Organización y Arquitectura de Computadores"
				},
				new Libro
				{
					Autor = "Homero",
					Edicion = "2005",
					Editorial = "Edimat Libros",
					Imagen = "https://i.imgur.com/PsK9lpi.jpg",
					ISBN = "9788497644907",
					Stock = 10,
					Titulo = "La iliada"
				},
				new Libro
				{
					Autor = "Robert C. Martin",
					Edicion = "1 ed.",
					Editorial = "Prentice Hall",
					Imagen = "https://i.imgur.com/XyEK93p.jpg",
					ISBN = "9780132350884",
					Stock = 1,
					Titulo = "Clean Code"
				},
				new Libro
				{
					Autor = "J. R. R. Tolkien",
					Edicion = "1",
					Editorial = "Booket",
					Imagen = "https://i.imgur.com/FMxBdpD.jpg",
					ISBN = "9788445000663",
					Stock = 0,
					Titulo = "El Señor de los Anillos I"
				},
				new Libro
				{
					Autor = "J. R. R. Tolkien",
					Edicion = "2012",
					Editorial = "Booket",
					Imagen = "https://i.imgur.com/0813LgS.jpg",
					ISBN = "9786070712739",
					Stock = 2,
					Titulo = "El Señor de los Anillos II"
				},
				new Libro
				{
					Autor = "J. R. R. Tolkien",
					Edicion = "Reprint edición",
					Editorial = "Planeta",
					Imagen = "https://i.imgur.com/Bxs4Ia5.jpg",
					ISBN = "9786070712746",
					Stock = 3,
					Titulo = "El Señor de los Anillos III"
				},
				new Libro
				{
					Autor = "Eduard Estivill",
					Edicion = "2003",
					Editorial = "DEBOLSILLO",
					Imagen = "https://i.imgur.com/7EWiKz2.jpg",
					ISBN = "9788497598637",
					Stock = 15,
					Titulo = "NECESITO DORMIR!"
				},
				new Libro
				{
					Autor = "Stephen King",
					Edicion = "Edición Media tie-in",
					Editorial = "Vintage Espanol",
					Imagen = "https://i.imgur.com/Sq51uG6.jpg",
					ISBN = "9780525566267",
					Stock = 6,
					Titulo = "It (Eso)"
				},
				new Libro
				{
					Autor = "Davis, Stephen R",
					Edicion = "2001",
					Editorial = "Hungry Minds Inc",
					Imagen = "https://i.imgur.com/6BKObap.jpg",
					ISBN = "9780764508141",
					Stock = 2,
					Titulo = "C# for Dummies"
				}
			);

        }

    }
}
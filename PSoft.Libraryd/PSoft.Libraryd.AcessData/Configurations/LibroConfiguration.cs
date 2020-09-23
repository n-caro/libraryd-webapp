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
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSoft.Libraryd.Domain.Entities;

namespace PSoft.Libraryd.AcessData.Configurations
{
    public class AlquilerConfiguration : IEntityTypeConfiguration<Alquiler>
    {
        public void Configure(EntityTypeBuilder<Alquiler> builder)
        {
            builder.Property(s => s.ClienteId)
                .IsRequired()
                .HasColumnName("Cliente");
            builder.Property(s => s.EstadoId)
                .IsRequired()
                .HasColumnName("Estado");
            builder.Property(s => s.ISBN)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(s => s.FechaAlquiler)
                .IsRequired(false)
                .HasColumnType("Date");
            builder.Property(s => s.FechaReserva)
                .IsRequired(false)
                .HasColumnType("Date");
            builder.Property(s => s.FechaDevolucion)
               .IsRequired(false)
               .HasColumnType("Date");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSoft.Libraryd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.AcessData.Configurations
{
    class EstadoDeAlquilerConfiguration : IEntityTypeConfiguration<EstadoDeAlquiler>
    {
        public void Configure(EntityTypeBuilder<EstadoDeAlquiler> builder)
        {
            builder.HasKey(o => o.EstadoId);
            builder.Property(s => s.EstadoId)
                .IsRequired();
            builder.Property(s => s.Descripcion)
                .IsRequired()
                .HasMaxLength(45);
        }
    }
}

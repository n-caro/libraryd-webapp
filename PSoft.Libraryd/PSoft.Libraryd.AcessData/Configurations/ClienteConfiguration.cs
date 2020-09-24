using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSoft.Libraryd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSoft.Libraryd.AcessData.Configurations
{
    class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(s => s.DNI)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(s => s.Nombre)
                .IsRequired()
                .HasMaxLength(45);
            builder.Property(s => s.Apellido)
                .IsRequired()
                .HasMaxLength(45);
            builder.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(45);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSoft.Libraryd.Domain.Entities;

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
            // PRELOAD DATA: Libro
            builder.HasData(
                new EstadoDeAlquiler { EstadoId = 1, Descripcion = "Reservado" },
                new EstadoDeAlquiler { EstadoId = 2, Descripcion = "Alquilado" },
                new EstadoDeAlquiler { EstadoId = 3, Descripcion = "Cancelado" }
            );
        }
    }
}

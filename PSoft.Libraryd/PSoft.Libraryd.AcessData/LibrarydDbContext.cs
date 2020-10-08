using Microsoft.EntityFrameworkCore;
using PSoft.Libraryd.AcessData.Configurations;
using PSoft.Libraryd.Domain.Entities;

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
        public LibrarydDbContext()
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

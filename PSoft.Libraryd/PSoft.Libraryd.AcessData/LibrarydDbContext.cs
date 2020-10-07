using Microsoft.EntityFrameworkCore;
using PSoft.Libraryd.AcessData.Configurations;
using PSoft.Libraryd.Domain.Entities;

namespace PSoft.Libraryd.AcessData
{
    public class LibrarydDbContext : DbContext
    {
        private const string connectionString = @"Server=localhost\SQLEXPRESS;Database=LibrarydDBdevtest;Trusted_Connection=True;"; // migrate to .config file
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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
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

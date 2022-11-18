namespace BusBookingApi.Infrastructure
{
    using Microsoft.EntityFrameworkCore;

    public class BusBookingApiDbContext : DbContext
    {
        public BusBookingApiDbContext(DbContextOptions<BusBookingApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Clientes.Domain.Cliente> Clientes => Set<Clientes.Domain.Cliente>();
        public DbSet<Rutas.Domain.Ruta> Rutas => Set<Rutas.Domain.Ruta>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ClienteEntityConfiguration().Configure(modelBuilder.Entity<Clientes.Domain.Cliente>());
            new RutaEntityConfiguration().Configure(modelBuilder.Entity<Rutas.Domain.Ruta>());
            new ViajeEntityConfiguration().Configure(modelBuilder.Entity<Rutas.Domain.Viaje>());
            new AsientoEntityConfiguration().Configure(modelBuilder.Entity<Rutas.Domain.Asiento>());
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteEntityConfiguration).Assembly);
        }
    }
}

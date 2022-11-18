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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ClienteEntityConfiguration().Configure(modelBuilder.Entity<Clientes.Domain.Cliente>());
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteEntityConfiguration).Assembly);
        }
    }
}

namespace BusBookingApi.Infrastructure
{
    using BusBookingApi.Rutas.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ViajeEntityConfiguration : IEntityTypeConfiguration<Viaje>
    {
        public void Configure(EntityTypeBuilder<Viaje> builder)
        {
            builder.ToTable("Viajes");

            builder.Property(v => v.Salida)
                .HasConversion(
                    value => value,
                    value => DateTime.SpecifyKind(value, DateTimeKind.Utc));

            builder.Property(v => v.Llegada)
                .HasConversion(
                    value => value,
                    value => DateTime.SpecifyKind(value, DateTimeKind.Utc));

            builder.HasMany(v => v.Asientos)
                .WithOne()
                .HasForeignKey(a => a.ViajeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

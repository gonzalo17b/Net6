namespace BusBookingApi.Infrastructure
{
    using BusBookingApi.Rutas.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RutaEntityConfiguration : IEntityTypeConfiguration<Ruta>
    {
        public void Configure(EntityTypeBuilder<Ruta> builder)
        {
            builder.ToTable("Rutas");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id)
                .HasMaxLength(10)
                .IsRequired();

            builder.HasMany(r => r.Viajes)
                .WithOne()
                .HasForeignKey(v => v.RutaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

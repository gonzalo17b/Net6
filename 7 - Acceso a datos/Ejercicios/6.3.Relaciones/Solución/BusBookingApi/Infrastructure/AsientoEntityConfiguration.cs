namespace BusBookingApi.Infrastructure
{
    using BusBookingApi.Rutas.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AsientoEntityConfiguration : IEntityTypeConfiguration<Asiento>
    {
        public void Configure(EntityTypeBuilder<Asiento> builder)
        {
            builder.ToTable("Asientos");

            builder.HasKey(a => new { a.Id, a.ViajeId });

            builder.Property(a => a.Id)
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(a => a.Situacion)
                .HasConversion(
                    value => value.ToString(),
                    stringValue => Enum.Parse<SituacionAsiento>(stringValue));

            builder.Property(a => a.Espacio)
                .HasConversion(
                    value => value.ToString(),
                    stringValue => Enum.Parse<EspacioAsiento>(stringValue));
        }
    }
}

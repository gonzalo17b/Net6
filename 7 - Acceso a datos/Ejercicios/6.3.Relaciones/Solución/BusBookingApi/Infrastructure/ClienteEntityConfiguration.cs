namespace BusBookingApi.Infrastructure
{
    using BusBookingApi.Clientes.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ClienteEntityConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Dni);

            builder.Property(c => c.Dni)
                .HasColumnName("Id")
                .HasMaxLength(9)
                .IsRequired();

            builder.Property(c => c.Nombre)
                .IsRequired();

            builder.Property(c => c.Apellidos)
                .IsRequired();
        }
    }
}

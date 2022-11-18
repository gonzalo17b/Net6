namespace BusBookingApi.Clientes.Domain
{
    using System.Diagnostics.CodeAnalysis;

    public class Cliente
    {
        public string Dni { get; }

        public string Nombre { get; private set; }

        public string Apellidos { get; private set; }

        public string? Email { get; private set; }

        public string? Telefono { get; private set; }

        public string? Foto { get; private set; }

        public Cliente(string dni, string nombre, string apellidos)
        {
            if (string.IsNullOrEmpty(dni))
            {
                throw new ArgumentException($"'{nameof(dni)}' cannot be null or empty.", nameof(dni));
            }

            Dni = dni;
            SetFullName(nombre, apellidos);
        }

        [MemberNotNull(nameof(Nombre))]
        [MemberNotNull(nameof(Apellidos))]
        public void SetFullName(string nombre, string apellidos)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ArgumentException($"'{nameof(nombre)}' cannot be null or empty.", nameof(nombre));
            }

            if (string.IsNullOrEmpty(apellidos))
            {
                throw new ArgumentException($"'{nameof(apellidos)}' cannot be null or empty.", nameof(apellidos));
            }

            Nombre = nombre;
            Apellidos = apellidos;
        }
    }
}

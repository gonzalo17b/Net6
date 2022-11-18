namespace BusBookingApi.Clientes.Domain
{
    public class ClienteQueryModel
    {
        public string Dni { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Foto { get; set; }
    }
}

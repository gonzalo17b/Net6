namespace BusBookingApi.Clientes;

public class Cliente
{
    public string Dni { get; set; } = string.Empty;

    public string Nombre { get; set; } = string.Empty;

    public string Apellidos { get; set; } = string.Empty;

    public string? Email { get; set; }

    public string? Direccion { get; set; }

    public string? Foto { get; set; }
}
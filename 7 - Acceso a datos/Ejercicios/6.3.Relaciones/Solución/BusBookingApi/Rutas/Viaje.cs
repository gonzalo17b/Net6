namespace BusBookingApi.Rutas;

public class Viaje
{
    public int Id { get; set; }

    public DateTime Salida { get; set; }

    public DateTime Llegada { get; set; }

    public Viaje() { }

    public Viaje(Domain.Viaje viaje)
    {
        Id = viaje.Id;
        Salida = viaje.Salida;
        Llegada = viaje.Llegada;
    }
}
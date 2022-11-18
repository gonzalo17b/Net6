namespace BusBookingApi.Rutas;

public class Ruta
{
    public string Id { get; set; } = string.Empty;

    public string Origen { get; set; } = string.Empty;

    public string Destino { get; set; } = string.Empty;

    public Ruta() { }

    public Ruta(Domain.Ruta ruta)
    {
        Id = ruta.Id;
        Origen = ruta.Origen;
        Destino = ruta.Destino;
    }
}
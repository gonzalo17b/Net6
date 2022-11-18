namespace BusBookingApi.Rutas;

public class Asiento
{
    public string Id { get; set; } = string.Empty;

    public string Situacion { get; set; } = string.Empty;

    public string Espacio { get; set; } = string.Empty;

    public Asiento() { }

    public Asiento(Domain.Asiento asiento)
    {
        Id = asiento.Id;
        Situacion = asiento.Situacion.ToString();
        Espacio = asiento.Espacio.ToString();
    }
}
namespace BusBookingApi.Rutas.Domain
{
    public class Asiento
    {
        public string Id { get; }
        public int ViajeId { get; }
        public SituacionAsiento Situacion { get; }
        public EspacioAsiento Espacio { get; }

        public Asiento(string id, int viajeId, SituacionAsiento situacion, EspacioAsiento espacio)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException($"'{nameof(id)}' cannot be null or empty.", nameof(id));
            }
            Id = id;
            ViajeId = viajeId;
            Situacion = situacion;
            Espacio = espacio;
        }
    }

    public enum SituacionAsiento
    {
        Otro,
        Ventana,
        Pasillo,
    }

    public enum EspacioAsiento
    {
        Normal,
        Grande,
    }
}

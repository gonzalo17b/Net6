namespace BusBookingApi.Rutas.Domain
{
    public class Viaje
    {
        public int Id { get; set; }
        public string RutaId { get; }

        public DateTime Salida { get; }
        public DateTime Llegada { get; }

        private readonly List<Asiento> _asientos = new List<Asiento>();
        public IEnumerable<Asiento> Asientos => _asientos;

        public Viaje(string rutaId, DateTime salida, DateTime llegada)
        {
            if (string.IsNullOrEmpty(rutaId))
            {
                throw new ArgumentException($"'{nameof(rutaId)}' cannot be null or empty.", nameof(rutaId));
            }
            if (salida.Kind != DateTimeKind.Utc)
            {
                throw new ArgumentException($"'La fecha de salida debe estar en UTC.", nameof(salida));
            }
            if (llegada.Kind != DateTimeKind.Utc)
            {
                throw new ArgumentException($"'La fecha de llegada debe estar en UTC.", nameof(llegada));
            }
            if (llegada <= salida)
            {
                throw new ArgumentException($"'La fecha de llegada debe ser posterior a la de salida.", nameof(llegada));
            }

            RutaId = rutaId;
            Salida = salida;
            Llegada = llegada;
        }

        public void AddAsiento(string id, SituacionAsiento situacion, EspacioAsiento espacio)
        {
            _asientos.Add(new Asiento(id, Id, situacion, espacio));
        }
    }
}

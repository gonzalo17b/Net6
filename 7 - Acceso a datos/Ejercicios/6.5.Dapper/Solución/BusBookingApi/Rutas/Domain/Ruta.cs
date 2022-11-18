namespace BusBookingApi.Rutas.Domain
{
    public class Ruta
    {
        public string Id { get; }

        public string Origen { get; private set; }

        public string Destino { get; private set; }

        private readonly List<Viaje> _viajes = new List<Viaje>();
        public IEnumerable<Viaje> Viajes => _viajes;

        public Ruta(string id, string origen, string destino)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException($"'{nameof(id)}' cannot be null or empty.", nameof(id));
            }

            if (string.IsNullOrEmpty(origen))
            {
                throw new ArgumentException($"'{nameof(origen)}' cannot be null or empty.", nameof(origen));
            }

            if (string.IsNullOrEmpty(destino))
            {
                throw new ArgumentException($"'{nameof(destino)}' cannot be null or empty.", nameof(destino));
            }

            Id = id;
            Origen = origen;
            Destino = destino;
        }

        public void AddViaje(DateTime salida, DateTime llegada)
        {
            _viajes.Add(new Viaje(Id, salida, llegada));
        }
    }
}

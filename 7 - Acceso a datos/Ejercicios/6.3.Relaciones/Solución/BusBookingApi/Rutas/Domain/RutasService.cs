namespace BusBookingApi.Rutas.Domain
{
    using BusBookingApi.Exceptions;

    public interface IRutasService
    {
        IEnumerable<Ruta> GetRutas();
        Ruta GetRuta(string id);
        IEnumerable<Viaje> GetViajes(string rutaId);
        Viaje GetViaje(string rutaId, int viajeId);
        IEnumerable<Asiento> GetAsientos(string rutaId, int viajeId);
        Asiento GetAsiento(string rutaId, int viajeId, string asientoId);
    }

    public class RutasService : IRutasService
    {
        private readonly Dictionary<string, Ruta> _rutas = new();

        public IEnumerable<Ruta> GetRutas()
        {
            return _rutas.Values;
        }

        public Ruta GetRuta(string id)
        {
            Ruta? ruta;
            if (!_rutas.TryGetValue(id, out ruta))
            {
                throw new EntityNotFoundException("La ruta no existe");
            }
            return ruta;
        }

        public IEnumerable<Viaje> GetViajes(string rutaId)
        {
            return GetRuta(rutaId).Viajes;
        }

        public Viaje GetViaje(string rutaId, int viajeId)
        {
            var viaje = GetRuta(rutaId).Viajes.SingleOrDefault(v => v.Id == viajeId);
            if (viaje is null)
            {
                throw new EntityNotFoundException("El viaje no existe");
            }
            return viaje;
        }

        public IEnumerable<Asiento> GetAsientos(string rutaId, int viajeId)
        {
            return GetViaje(rutaId, viajeId).Asientos;
        }

        public Asiento GetAsiento(string rutaId, int viajeId, string asientoId)
        {
            var asiento = GetViaje(rutaId, viajeId).Asientos.SingleOrDefault(v => v.Id == asientoId);
            if (asiento is null)
            {
                throw new EntityNotFoundException("El asiento no existe");
            }
            return asiento;
        }
    }
}

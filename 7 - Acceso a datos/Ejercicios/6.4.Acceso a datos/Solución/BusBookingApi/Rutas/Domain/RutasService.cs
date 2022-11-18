namespace BusBookingApi.Rutas.Domain
{
    using BusBookingApi.Exceptions;
    using BusBookingApi.Infrastructure;
    using Microsoft.EntityFrameworkCore;

    public interface IRutasService
    {
        Task<IEnumerable<Ruta>> GetRutas();
        Task<Ruta> GetRuta(string id);
        Task<IEnumerable<Viaje>> GetViajes(string rutaId);
        Task<Viaje> GetViaje(string rutaId, int viajeId);
        Task<IEnumerable<Asiento>> GetAsientos(string rutaId, int viajeId);
        Task<Asiento> GetAsiento(string rutaId, int viajeId, string asientoId);
    }

    public class RutasService : IRutasService
    {
        private readonly BusBookingApiDbContext _dbContext;

        public RutasService(BusBookingApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Ruta>> GetRutas()
        {
            return await _dbContext.Rutas.ToListAsync();
        }

        public async Task<Ruta> GetRuta(string id)
        {
            var ruta = await _dbContext.Rutas.FindAsync(id);
            if (ruta is null)
            {
                throw new EntityNotFoundException("La ruta no existe");
            }
            return ruta;
        }

        public async Task<IEnumerable<Viaje>> GetViajes(string rutaId)
        {
            var ruta = await _dbContext.Rutas
                .Include(r => r.Viajes)
                .FirstOrDefaultAsync(r => r.Id == rutaId);
            if (ruta is null)
            {
                throw new EntityNotFoundException("La ruta no existe");
            }
            return ruta.Viajes;
        }

        public async Task<Viaje> GetViaje(string rutaId, int viajeId)
        {
            var ruta = await _dbContext.Rutas
               .Include(r => r.Viajes)
               .FirstOrDefaultAsync(r => r.Id == rutaId);
            if (ruta is null)
            {
                throw new EntityNotFoundException("La ruta no existe");
            }
            var viaje = ruta.Viajes.SingleOrDefault(v => v.Id == viajeId);
            if (viaje is null)
            {
                throw new EntityNotFoundException("El viaje no existe");
            }
            return viaje;
        }

        public async Task<IEnumerable<Asiento>> GetAsientos(string rutaId, int viajeId)
        {
            var ruta = await _dbContext.Rutas
                .Include(r => r.Viajes)
                .ThenInclude(v => v.Asientos)
                .FirstOrDefaultAsync(r => r.Id == rutaId);
            if (ruta is null)
            {
                throw new EntityNotFoundException("La ruta no existe");
            }
            var viaje = ruta.Viajes.SingleOrDefault(v => v.Id == viajeId);
            if (viaje is null)
            {
                throw new EntityNotFoundException("El viaje no existe");
            }
            return viaje.Asientos;
        }

        public async Task<Asiento> GetAsiento(string rutaId, int viajeId, string asientoId)
        {
            var ruta = await _dbContext.Rutas
                .Include(r => r.Viajes)
                .ThenInclude(v => v.Asientos)
                .FirstOrDefaultAsync(r => r.Id == rutaId);
            if (ruta is null)
            {
                throw new EntityNotFoundException("La ruta no existe");
            }
            var viaje = ruta.Viajes.SingleOrDefault(v => v.Id == viajeId);
            if (viaje is null)
            {
                throw new EntityNotFoundException("El viaje no existe");
            }
            var asiento = viaje.Asientos.SingleOrDefault(v => v.Id == asientoId);
            if (asiento is null)
            {
                throw new EntityNotFoundException("El asiento no existe");
            }
            return asiento;
        }
    }
}

namespace BusBookingApi.Rutas.Domain
{
    using BusBookingApi.Exceptions;
    using Dapper;
    using System.Data;

    public interface IRutasService
    {
        Task<IEnumerable<RutaQueryModel>> GetRutas();
        Task<RutaQueryModel> GetRuta(string id);
        Task<IEnumerable<ViajeQueryModel>> GetViajes(string rutaId);
        Task<ViajeQueryModel> GetViaje(string rutaId, int viajeId);
        Task<IEnumerable<AsientoQueryModel>> GetAsientos(string rutaId, int viajeId);
        Task<AsientoQueryModel> GetAsiento(string rutaId, int viajeId, string asientoId);
    }

    public class RutasService : IRutasService
    {
        private readonly IDbConnection _dbConnection;

        public RutasService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task<IEnumerable<RutaQueryModel>> GetRutas()
        {
            return _dbConnection.QueryAsync<RutaQueryModel>("SELECT Id, Origen, Destino FROM Rutas");
        }

        public async Task<RutaQueryModel> GetRuta(string id)
        {
            var ruta = await _dbConnection.QuerySingleOrDefaultAsync<RutaQueryModel?>("SELECT Id, Origen, Destino FROM Rutas WHERE Id = @Id", new { Id = id });
            if (ruta is null)
            {
                throw new EntityNotFoundException("La ruta no existe");
            }
            return ruta;
        }

        public async Task<IEnumerable<ViajeQueryModel>> GetViajes(string rutaId)
        {
            using var multi = await _dbConnection.QueryMultipleAsync(
                sql: @"SELECT Id, Origen, Destino FROM Rutas WHERE Id = @Id;
                       SELECT Id, Salida, Llegada FROM Viajes WHERE RutaId = @Id",
                param: new { Id = rutaId });

            var ruta = await multi.ReadSingleOrDefaultAsync<RutaQueryModel?>();
            if (ruta is null)
            {
                throw new EntityNotFoundException("La ruta no existe");
            }
            return await multi.ReadAsync<ViajeQueryModel>();
        }

        public async Task<ViajeQueryModel> GetViaje(string rutaId, int viajeId)
        {
            using var multi = await _dbConnection.QueryMultipleAsync(
                sql: @"SELECT Id, Origen, Destino FROM Rutas WHERE Id = @RutaId;
                       SELECT Id, Salida, Llegada FROM Viajes WHERE RutaId = @RutaId AND Id = @ViajeId",
                param: new { RutaId = rutaId, ViajeId = viajeId });

            var ruta = await multi.ReadSingleOrDefaultAsync<RutaQueryModel?>();
            if (ruta is null)
            {
                throw new EntityNotFoundException("La ruta no existe");
            }
            var viaje = await multi.ReadSingleOrDefaultAsync<ViajeQueryModel?>();
            if (viaje is null)
            {
                throw new EntityNotFoundException("El viaje no existe");
            }
            return viaje;
        }

        public async Task<IEnumerable<AsientoQueryModel>> GetAsientos(string rutaId, int viajeId)
        {
            using var multi = await _dbConnection.QueryMultipleAsync(
                sql: @"SELECT Id, Origen, Destino FROM Rutas WHERE Id = @RutaId;
                       SELECT Id, Salida, Llegada FROM Viajes WHERE RutaId = @RutaId AND Id = @ViajeId;
                       SELECT Asientos.Id, Situacion, Espacio 
                            FROM Asientos 
                            INNER JOIN Viajes ON Asientos.ViajeId = Viajes.Id
                            WHERE RutaId = @RutaId AND ViajeId = @ViajeId;",
                param: new { RutaId = rutaId, ViajeId = viajeId });

            var ruta = await multi.ReadSingleOrDefaultAsync<RutaQueryModel?>();
            if (ruta is null)
            {
                throw new EntityNotFoundException("La ruta no existe");
            }
            var viaje = await multi.ReadSingleOrDefaultAsync<ViajeQueryModel?>();
            if (viaje is null)
            {
                throw new EntityNotFoundException("El viaje no existe");
            }
            return await multi.ReadAsync<AsientoQueryModel>();
        }

        public async Task<AsientoQueryModel> GetAsiento(string rutaId, int viajeId, string asientoId)
        {
            using var multi = await _dbConnection.QueryMultipleAsync(
                sql: @"SELECT Id, Origen, Destino FROM Rutas WHERE Id = @RutaId;
                       SELECT Id, Salida, Llegada FROM Viajes WHERE RutaId = @RutaId AND Id = @ViajeId;
                       SELECT Asientos.Id, Situacion, Espacio 
                            FROM Asientos 
                            INNER JOIN Viajes ON Asientos.ViajeId = Viajes.Id
                            WHERE RutaId = @RutaId AND ViajeId = @ViajeId AND Asientos.Id = @AsientoId;",
                param: new { RutaId = rutaId, ViajeId = viajeId, AsientoId = asientoId });

            var ruta = await multi.ReadSingleOrDefaultAsync<RutaQueryModel?>();
            if (ruta is null)
            {
                throw new EntityNotFoundException("La ruta no existe");
            }
            var viaje = await multi.ReadSingleOrDefaultAsync<ViajeQueryModel?>();
            if (viaje is null)
            {
                throw new EntityNotFoundException("El viaje no existe");
            }
            var asiento = await multi.ReadSingleOrDefaultAsync<AsientoQueryModel?>();
            if (asiento is null)
            {
                throw new EntityNotFoundException("El asiento no existe");
            }
            return asiento;
        }
    }
}

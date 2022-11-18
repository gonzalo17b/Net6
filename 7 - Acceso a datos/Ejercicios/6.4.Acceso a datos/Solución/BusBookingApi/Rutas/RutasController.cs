namespace BusBookingApi.Rutas
{
    using Microsoft.AspNetCore.Mvc;
    using BusBookingApi.Rutas.Domain;

    [ApiController]
    [Route("v{version:apiVersion}/rutas")]
    [ApiVersion("1.0")]
    public class RutasController : ControllerBase
    {
        private readonly IRutasService _service;

        public RutasController(IRutasService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Ruta>> GetRutas()
        {
            var rutas = await _service.GetRutas();
            return rutas.Select(r => new Ruta(r));
        }

        [HttpGet("{rutaId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Ruta))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Ruta> GetRuta(string rutaId)
        {
            var ruta = await _service.GetRuta(rutaId);
            return new Ruta(ruta);
        }

        [HttpGet("{rutaId}/viajes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Viaje>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<Viaje>> GetViajesAsync(string rutaId)
        {
            var viajes = await _service.GetViajes(rutaId);
            return viajes.Select(v => new Viaje(v));
        }

        [HttpGet("{rutaId}/viajes/{viajeId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Viaje))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Viaje> GetViajeAsync(string rutaId, int viajeId)
        {
            var viaje = await _service.GetViaje(rutaId, viajeId);
            return new Viaje(viaje);
        }

        [HttpGet("{rutaId}/viajes/{viajeId}/asientos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Asiento>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<Asiento>> GetAsientosAsync(string rutaId, int viajeId)
        {
            var viajes =await _service.GetAsientos(rutaId, viajeId);
            return viajes.Select(a => new Asiento(a));
        }

        [HttpGet("{rutaId}/viajes/{viajeId}/asientos/{asientoId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Asiento))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Asiento> GetAsientoAsync(string rutaId, int viajeId, string asientoId)
        {
            var asiento = await _service.GetAsiento(rutaId, viajeId, asientoId);
            return new Asiento(asiento);
        }

    }
}

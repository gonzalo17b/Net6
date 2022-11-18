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
        public IEnumerable<Ruta> GetRutas()
        {
            IEnumerable<Domain.Ruta> rutas = _service.GetRutas();
            return rutas.Select(r => new Ruta(r));
        }

        [HttpGet("{rutaId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Ruta))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Ruta GetRuta(string rutaId)
        {
            Domain.Ruta ruta = _service.GetRuta(rutaId);
            return new Ruta(ruta);
        }

        [HttpGet("{rutaId}/viajes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Viaje>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<Viaje> GetViajes(string rutaId)
        {
            IEnumerable<Domain.Viaje> viajes = _service.GetViajes(rutaId);
            return viajes.Select(v => new Viaje(v));
        }

        [HttpGet("{rutaId}/viajes/{viajeId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Viaje))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Viaje GetViaje(string rutaId, int viajeId)
        {
            Domain.Viaje viaje = _service.GetViaje(rutaId, viajeId);
            return new Viaje(viaje);
        }

        [HttpGet("{rutaId}/viajes/{viajeId}/asientos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Asiento>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<Asiento> GetAsientos(string rutaId, int viajeId)
        {
            IEnumerable<Domain.Asiento> viajes = _service.GetAsientos(rutaId, viajeId);
            return viajes.Select(a => new Asiento(a));
        }

        [HttpGet("{rutaId}/viajes/{viajeId}/asientos/{asientoId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Asiento))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Asiento GetAsiento(string rutaId, int viajeId, string asientoId)
        {
            Domain.Asiento asiento = _service.GetAsiento(rutaId, viajeId, asientoId);
            return new Asiento(asiento);
        }

    }
}

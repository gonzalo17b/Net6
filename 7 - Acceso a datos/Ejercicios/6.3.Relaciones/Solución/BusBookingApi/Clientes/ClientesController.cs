namespace BusBookingApi.Clientes
{
    using Microsoft.AspNetCore.Mvc;
    using BusBookingApi.Clientes.Domain;

    [ApiController]
    [Route("v{version:apiVersion}/clientes")]
    [ApiVersion("1.0")]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesService _service;

        public ClientesController(IClientesService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Cliente> GetClientes()
        {
            return _service.GetClientes().Select(c => new Cliente(c));
        }

        [HttpGet("{dni}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Cliente))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCliente(string dni)
        {
            Domain.Cliente cliente = _service.GetCliente(dni);
            return Ok(new Cliente(cliente));
        }

        [HttpPost("{dni}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateCliente(string dni, Cliente request)
        {
            if (request.Dni != dni)
            {
                return BadRequest("El dni no coincide");
            }

            var cliente = new Domain.Cliente(request.Dni, request.Nombre, request.Apellidos);
            _service.CreateCliente(cliente);

            return Created($"/Clientes/{dni}", cliente);
        }

        [HttpPut("{dni}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateCliente(string dni, Cliente cliente)
        {
            if (cliente.Dni != dni)
            {
                return BadRequest("El dni no coincide");
            }

            _service.UpdateCliente(dni, cliente.Nombre, cliente.Apellidos);

            return NoContent();
        }

        [HttpDelete("{dni}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteCliente(string dni)
        {
            _service.DeleteCliente(dni);

            return NoContent();
        }
    }
}

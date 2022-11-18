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
        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            var clientes = await _service.GetClientes();
            return clientes.Select(c => new Cliente(c));
        }

        [HttpGet("{dni}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Cliente))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Cliente> GetCliente(string dni)
        {
            var cliente = await _service.GetCliente(dni);
            return new Cliente(cliente);
        }

        [HttpPost("{dni}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> CreateCliente(string dni, Cliente request)
        {
            if (request.Dni != dni)
            {
                return BadRequest("El dni no coincide");
            }

            var cliente = new Domain.Cliente(request.Dni, request.Nombre, request.Apellidos);
            await _service.CreateCliente(cliente);

            return Created($"/Clientes/{dni}", cliente);
        }

        [HttpPut("{dni}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCliente(string dni, Cliente cliente)
        {
            if (cliente.Dni != dni)
            {
                return BadRequest("El dni no coincide");
            }

            await _service.UpdateCliente(dni, cliente.Nombre, cliente.Apellidos);

            return NoContent();
        }

        [HttpDelete("{dni}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCliente(string dni)
        {
            await _service.DeleteCliente(dni);

            return NoContent();
        }
    }
}

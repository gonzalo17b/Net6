namespace BusBookingApi.Clientes
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("v{version:apiVersion}/clientes")]
    [ApiVersion("2.0")]
    public class ClientsV2Controller : ControllerBase
    {
        private readonly IClientsService _service;

        public ClientsV2Controller(IClientsService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Cliente> GetClientes()
        {
            return _service.GetClientes();
        }

        [HttpGet("{dni}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Cliente))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCliente(string dni)
        {
            Cliente? cliente = _service.GetCliente(dni);
            if (cliente is null)
            {
                return NotFound("No existe un cliente con ese DNI");
            }

            return Ok(cliente);
        }

        [HttpPost("{dni}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateCliente(string dni, Cliente cliente)
        {
            if (cliente.Dni != dni)
            {
                return BadRequest("El dni no coincide");
            }

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

            _service.UpdateCliente(cliente);


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

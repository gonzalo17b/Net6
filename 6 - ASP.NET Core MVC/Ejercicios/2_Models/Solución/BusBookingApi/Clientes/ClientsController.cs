namespace BusBookingApi.Clientes
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("v{version:apiVersion}/clientes")]
    [ApiVersion("1.0")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _service;

        public ClientsController(IClientsService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Cliente> GetClientes()
        {
            return _service.GetClientes();
        }

        [HttpGet("{dni}")]
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
        public IActionResult DeleteCliente(string dni)
        {
            _service.DeleteCliente(dni);

            return NoContent();
        }
    }
}

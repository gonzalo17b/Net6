using BusBookingApi.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace BusBookingApi.Controllers
{
    [Route("/api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesService _clientesService;
        public ClientesController(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetClientes()
        {
            var clientes = _clientesService.GetClientes();
            return Ok(clientes);
        }

        [HttpGet("{dni}")]
        public ActionResult<Cliente> GetCliente(string dni)
        {
            var cliente = _clientesService.GetClient(dni);
            if (cliente is null)
                return NotFound($"No se ha encontrado el cliente con el dni {dni}");

            return Ok(cliente);
        }

        [HttpPost]
        public ActionResult CreateCliente(Cliente cliente)
        {
            var clienteExiste = !(_clientesService.GetClient(cliente.Dni) is null);
            if (clienteExiste)
                return BadRequest($"El cliente con dni {cliente.Dni} ya existe");

            _clientesService.CreateCliente(cliente);
            return Created($"api/clientes/{cliente.Dni}", cliente);
        }

        [HttpPut("{dni}")]
        public ActionResult UpdateCliente(string dni, Cliente cliente)
        {
            var clienteExiste = _clientesService.GetClient(dni) is not null;
            if(!clienteExiste)
                return BadRequest($"El cliente con dni {cliente.Dni} no existe");

            _clientesService.UpdateCliente(dni, cliente);
            return NoContent();
        }

        [HttpDelete("{dni}")]
        public ActionResult DeleteCliente(string dni)
        {
            var clienteExiste = _clientesService.GetClient(dni) is not null;
            if (!clienteExiste)
                return BadRequest($"El cliente con dni {dni} no existe");

            return NoContent();
        }
    }
}

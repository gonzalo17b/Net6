

namespace BusBookingApi.Clientes
{
    public class ClientesService: IClientesService
    {
        private readonly Dictionary<string, Cliente> _clientes;
        private readonly ILogger<ClientesService> _logger;

        public ClientesService(ILogger<ClientesService> logger)
        {
            _logger = logger;
            _clientes = new Dictionary<string, Cliente>();
        }

        public IEnumerable<Cliente> GetClientes()
        {
            _logger.LogInformation($"Hola desde desde {nameof(GetClientes)}");
            return _clientes.Values;
        }

        public Cliente? GetClient(string dni)
        {
            Cliente? cliente = null;
            _clientes.TryGetValue(dni, out cliente);
            return cliente;
        }

        public void CreateCliente(Cliente cliente)
        {
            _clientes.Add(cliente.Dni, cliente);
        }

        public void DeleteCliente(string dni)
        {
            _clientes.Remove(dni);
        }

        public void UpdateCliente(string dni, Cliente cliente)
        {
           _clientes[dni] = cliente;
        }
    }
}

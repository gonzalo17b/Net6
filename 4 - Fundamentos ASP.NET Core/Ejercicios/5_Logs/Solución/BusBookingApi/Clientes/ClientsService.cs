namespace BusBookingApi.Clientes
{
    using BusBookingApi.Exceptions;
    using System.Collections.Concurrent;

    public interface IClientsService
    {
        IEnumerable<Cliente> GetClientes();

        Cliente GetCliente(string dni);

        void CreateCliente(Cliente cliente);

        void UpdateCliente(Cliente cliente);

        void DeleteCliente(string dni);
    }

    public class ClientsService : IClientsService
    {
        private readonly Dictionary<string, Cliente> _clientes = new();

        public IEnumerable<Cliente> GetClientes()
        {
            return _clientes.Values;
        }

        public Cliente GetCliente(string dni)
        {
            Cliente? cliente;
            if (!_clientes.TryGetValue(dni, out cliente))
            {
                throw new EntityNotFoundException("El cliente no existe");
            }
            return cliente;
        }

        public void CreateCliente(Cliente cliente)
        {
            if (!_clientes.TryAdd(cliente.Dni, cliente))
            {
                throw new EntityAlreadyExistingException("El cliente ya existe");
            }
        }

        public void UpdateCliente(Cliente cliente)
        {
            if (!_clientes.ContainsKey(cliente.Dni))
            {
                throw new EntityNotFoundException("El cliente no existe");
            }

            _clientes[cliente.Dni] = cliente;
        }

        public void DeleteCliente(string dni)
        {
            if (!_clientes.Remove(dni))
            {
                throw new EntityNotFoundException("El cliente no existe");
            }
        }
    }

    public class ConcurrentClientsService : IClientsService
    {
        private readonly ConcurrentDictionary<string, Cliente> _clientes = new();

        public IEnumerable<Cliente> GetClientes()
        {
            return _clientes.Values;
        }

        public Cliente GetCliente(string dni)
        {
            Cliente? cliente;
            if (!_clientes.TryGetValue(dni, out cliente))
            {
                throw new EntityNotFoundException("El cliente no existe");
            }
            return cliente;
        }

        public void CreateCliente(Cliente cliente)
        {
            if (!_clientes.TryAdd(cliente.Dni, cliente))
            {
                throw new EntityAlreadyExistingException("El cliente ya existe");
            }
        }

        public void UpdateCliente(Cliente cliente)
        {
            _clientes.AddOrUpdate(cliente.Dni,
                (_) => throw new EntityNotFoundException("El cliente no existe"),
                (_, _) => cliente);
        }

        public void DeleteCliente(string dni)
        {
            if (!_clientes.TryRemove(dni, out _))
            {
                throw new EntityNotFoundException("El cliente no existe");
            }
        }
    }
}

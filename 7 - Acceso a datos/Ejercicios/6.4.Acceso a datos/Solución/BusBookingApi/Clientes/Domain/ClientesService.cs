namespace BusBookingApi.Clientes.Domain
{
    using BusBookingApi.Exceptions;
    using BusBookingApi.Infrastructure;
    using Microsoft.EntityFrameworkCore;

    public interface IClientesService
    {
        Task<IEnumerable<Cliente>> GetClientes();

        Task<Cliente> GetCliente(string dni);

        Task CreateCliente(Cliente cliente);

        Task UpdateCliente(string dni, string nombre, string apellidos);

        Task DeleteCliente(string dni);
    }

    public class ClientesService : IClientesService
    {
        private readonly BusBookingApiDbContext _dbContext;

        public ClientesService(BusBookingApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _dbContext.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetCliente(string dni)
        {
            var cliente = await _dbContext.Clientes.FindAsync(dni);
            if (cliente is null)
            {
                throw new EntityNotFoundException("El cliente no existe");
            }
            return cliente;
        }

        public async Task CreateCliente(Cliente cliente)
        {
            var clienteExistente = await _dbContext.Clientes.FindAsync(cliente.Dni);
            if (clienteExistente is not null)
            {
                throw new EntityAlreadyExistingException("El cliente con ese DNI ya existe");
            }
            _dbContext.Clientes.Add(cliente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCliente(string dni, string nombre, string apellidos)
        {
            var cliente = await GetCliente(dni);
            cliente.SetFullName(nombre, apellidos);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCliente(string dni)
        {
            var cliente = await GetCliente(dni);
            _dbContext.Clientes.Remove(cliente);
            await _dbContext.SaveChangesAsync();
        }
    }
}

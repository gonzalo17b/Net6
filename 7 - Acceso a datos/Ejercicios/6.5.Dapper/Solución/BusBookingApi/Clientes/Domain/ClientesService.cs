namespace BusBookingApi.Clientes.Domain
{
    using BusBookingApi.Exceptions;
    using BusBookingApi.Infrastructure;
    using Dapper;
    using System.Data;

    public interface IClientesService
    {
        Task<IEnumerable<ClienteQueryModel>> GetClientes();

        Task<ClienteQueryModel> GetCliente(string dni);

        Task CreateCliente(Cliente cliente);

        Task UpdateCliente(string dni, string nombre, string apellidos);

        Task DeleteCliente(string dni);
    }

    public class ClientesService : IClientesService
    {
        private readonly IDbConnection _dbConnection;
        private readonly BusBookingApiDbContext _dbContext;

        public ClientesService(IDbConnection dbConnection, BusBookingApiDbContext dbContext)
        {
            _dbConnection = dbConnection;
            _dbContext = dbContext;
        }

        public Task<IEnumerable<ClienteQueryModel>> GetClientes()
        {
            return _dbConnection.QueryAsync<ClienteQueryModel>("SELECT Id AS Dni, Nombre, Apellidos, Email, Telefono, Foto FROM Clientes");
        }

        public async Task<ClienteQueryModel> GetCliente(string dni)
        {
            var cliente = await _dbConnection.QuerySingleOrDefaultAsync<ClienteQueryModel?>("SELECT Id AS Dni, Nombre, Apellidos, Email, Telefono, Foto FROM Clientes WHERE Id = @Dni", new { Dni = dni });
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
            var cliente = await _dbContext.Clientes.FindAsync(dni);
            if (cliente is null)
            {
                throw new EntityNotFoundException("El cliente no existe");
            }
            cliente.SetFullName(nombre, apellidos);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCliente(string dni)
        {
            var cliente = await _dbContext.Clientes.FindAsync(dni);
            if (cliente is null)
            {
                throw new EntityNotFoundException("El cliente no existe");
            }
            _dbContext.Clientes.Remove(cliente);
            await _dbContext.SaveChangesAsync();
        }
    }
}

namespace BusBookingApi.Clientes
{
    public interface IClientesService
    {
        IEnumerable<Cliente> GetClientes();
        Cliente? GetClient(string dni);

        void CreateCliente(Cliente cliente);
        void DeleteCliente(string dni);
        void UpdateCliente(string dni, Cliente cliente);
    }
}

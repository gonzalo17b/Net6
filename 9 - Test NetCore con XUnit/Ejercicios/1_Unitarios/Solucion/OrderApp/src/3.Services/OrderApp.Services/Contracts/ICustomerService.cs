using OrderApp.Models.Customers;

namespace OrderApp.Services.Contracts
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponse>> GetAlls();
        Task<CustomerResponse> Get(int id);
        Task<int> Create(CreateCustomerRequest customer);
        Task Update(int id, UpdateCustomerRequest customer);
        Task Delete(int id);
        Task DesactiveUser(int id);
    }
}

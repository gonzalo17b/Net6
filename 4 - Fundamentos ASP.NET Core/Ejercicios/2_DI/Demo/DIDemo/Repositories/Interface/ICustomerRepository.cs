using DIDemo.Models;

namespace DIDemo.Repositories.Interface
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
    }
}

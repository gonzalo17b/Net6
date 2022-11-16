using DIDemo.Models;
using DIDemo.Repositories;
using DIDemo.Repositories.Interface;

namespace DIDemo.Services
{
    public class CustomerService
    {
        private ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository)
        {
            Console.WriteLine($"Instanciamos {nameof(CustomerService)} at {DateTime.Now.ToShortDateString()}");
            _repository = repository;
        }

        public List<Customer> GetAllCustomers()
        {
            return _repository.GetAll();
        }
    }
}

using DIDemo.Models;
using DIDemo.Repositories;

namespace DIDemo.Services
{
    public class CustomerService
    {
        private CustomerRepository _repository;
        public CustomerService()
        {
            Console.WriteLine($"Instanciamos {nameof(CustomerService)} at {DateTime.Now.ToShortDateString()}");
            _repository = new CustomerRepository();
        }

        public List<Customer> GetAllCustomers()
        {
            return _repository.GetAll();
        }
    }
}

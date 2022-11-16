using DIDemo.Models;

namespace DIDemo.Repositories
{
    public class CustomerRepository
    {
        private MySqlConnection _connection;

        public CustomerRepository()
        {
            Console.WriteLine($"Instanciamos {nameof(CustomerRepository)} at {DateTime.Now.ToShortDateString()}");
            _connection = new MySqlConnection();            
        }

        public List<Customer> GetAll()
        {
            _connection.Connect("Esta sería mi cadena de conexión");
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "Julio", Email = "julio@gmail.com", Phone = "123456789"},
                new Customer { Id = 2, Name = "Pedro", Email = "pedro@gmail.com", Phone = "987654321"}
            };
        }
    }
}

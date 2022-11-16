
using DIDemo.Repositories.Interface;

namespace DIDemo.Repositories
{
    public class MySqlConnection : IDbConnection
    {
        public MySqlConnection()
        {
            Console.WriteLine($"Instanciamos {nameof(MySqlConnection)} at {DateTime.Now.ToShortDateString()}");
        }

        public bool Connect(string connectionString)
        {
            Console.WriteLine("Conectamos con SQL");
            return true;
        }
    }
}

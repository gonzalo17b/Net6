
namespace DIDemo.Repositories
{
    public class MySqlConnection
    {
        public MySqlConnection()
        {
            Console.WriteLine($"Instanciamos {nameof(MySqlConnection)} at {DateTime.Now.ToShortDateString()}");
        }


        public bool Connect(string connectionstring)
        {
            Console.WriteLine("Connections succeed");
            return true;
        }
    }
}

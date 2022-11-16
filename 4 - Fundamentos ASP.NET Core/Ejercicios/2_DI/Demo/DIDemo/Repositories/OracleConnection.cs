using DIDemo.Repositories.Interface;

namespace DIDemo.Repositories
{
    public class OracleConnection : IDbConnection
    {
        public OracleConnection()
        {
            Console.WriteLine($"Instanciamos {nameof(OracleConnection)} at {DateTime.Now.ToShortDateString()}");
        }

        public bool Connect(string connectionString)
        {
            Console.WriteLine("Se ha abierto la conexión con ORACLE");
            return true; 
        }
    }
}

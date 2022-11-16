namespace DIDemo.Repositories.Interface
{
    public interface IDbConnection
    {
        bool Connect(string connectionString);
    }
}

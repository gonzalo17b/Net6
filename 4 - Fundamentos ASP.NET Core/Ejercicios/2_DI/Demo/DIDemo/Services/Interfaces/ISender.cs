using DIDemo.Models;

namespace DIDemo.Services.Interfaces
{
    public interface ISender
    {
        void SendMessage(Customer customer, string message);
    }
}

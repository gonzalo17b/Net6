using DIDemo.Models;
using DIDemo.Services.Interfaces;

namespace DIDemo.Services
{
    public class SMSService : ISender
    {
        public SMSService()
        {
            Console.WriteLine($"Instanciamos {nameof(SMSService)} at {DateTime.Now.ToShortDateString()}");
        }
        public void SendMessage(Customer customer, string message)
        {
            Console.WriteLine("MESSAGE: " + message);
            Console.WriteLine($"{customer.Name} sent the message {message} by email");
        }
    }
}

using DIDemo.Models;

namespace DIDemo.Services
{
    public class EmailService
    {
        public EmailService()
        {
            Console.WriteLine($"Instanciamos {nameof(EmailService)} at {DateTime.Now.ToShortDateString()}");
        }

        public void Send(Customer customer, string message)
        {
            Console.WriteLine("MESSAGE: " + message);
            Console.WriteLine($"{customer.Name} sent the message {message} by email");
        }
    }
}

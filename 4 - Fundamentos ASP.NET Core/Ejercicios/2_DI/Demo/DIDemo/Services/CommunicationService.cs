using DIDemo.Models;

namespace DIDemo.Services
{
    public class CommunicationService
    {
        private EmailService _emailService;

        public CommunicationService()
        {
            Console.WriteLine($"Instanciamos {nameof(CommunicationService)} at {DateTime.Now.ToShortDateString()}");
            _emailService = new EmailService();
        }

        public void SendMessage(Customer customer, string message)
        {
            _emailService.Send(customer, message);
        }
    }
}

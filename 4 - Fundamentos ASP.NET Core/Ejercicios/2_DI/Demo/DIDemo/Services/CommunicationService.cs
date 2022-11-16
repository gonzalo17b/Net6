using DIDemo.Models;
using DIDemo.Services.Interfaces;

namespace DIDemo.Services
{
    public class CommunicationService
    {
        private ISender _senderService;

        public CommunicationService(ISender sender)
        {
            Console.WriteLine($"Instanciamos {nameof(CommunicationService)} at {DateTime.Now.ToShortDateString()}");
            _senderService = sender;
        }

        public void SendMessage(Customer customer, string message)
        {
            _senderService.SendMessage(customer, message);
        }
    }
}

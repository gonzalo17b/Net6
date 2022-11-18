namespace OrderApp.Models.Customers
{
    public class UpdateCustomerRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}

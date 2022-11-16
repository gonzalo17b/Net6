using DIDemo.Services;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/send", () =>
{
    //DEPENDENCIAS

    var custormerService = new CustomerService();
    var comunicationService = new CommunicationService();

    var customers = custormerService.GetAllCustomers();

    var message = "This is the generic message to all the customers";

    foreach (var customer in customers)
    {
        comunicationService.SendMessage(customer, message);
    }
});

app.Run();

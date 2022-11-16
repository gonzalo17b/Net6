using DIDemo.Repositories;
using DIDemo.Repositories.Interface;
using DIDemo.Services;
using DIDemo.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ISender, SMSService>();
builder.Services.AddTransient<IDbConnection, OracleConnection>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<CustomerService>();
builder.Services.AddTransient<CommunicationService>();

var app = builder.Build();

app.MapGet("/", (ISender sender) => {
    // cualquier cosa con sender
    Console.WriteLine("********************");
});

app.MapGet("/send", (CustomerService custormerService, CommunicationService comunicationService) =>
{
    var customers = custormerService.GetAllCustomers();

    var message = "This is the generic message to all the customers";

    foreach (var customer in customers)
    {
        comunicationService.SendMessage(customer, message);
    }
});

app.Run();

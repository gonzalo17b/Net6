using BusBookingApi.Clientes;
using BusBookingApi.Middelwares;
using BusBookingApi.Random;
using BusBookingApi.Random.Interfaces;
using BusBookingApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ISingeltonRandomService, RandomService>();
builder.Services.AddScoped<IScopedRandomService, RandomService>();
builder.Services.AddTransient<ITransientRandomService, RandomService>();
builder.Services.AddSingleton<EndpointLoginService>();

var app = builder.Build();
app.UseMiddleware<EndpointLoggerMiddleware>();

app.MapGet("/", () => "Hello World!");

app.MapGet("/logCounter", (EndpointLoginService endpointService) =>
{
    return endpointService.GetElements();
});

app.MapClientEndpoints()
   .MapRandomEndpoints();

app.Run();

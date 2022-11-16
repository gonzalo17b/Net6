using BusBookingApi.Clientes;
using BusBookingApi.Random;
using BusBookingApi.Random.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ISingeltonRandomService, RandomService>();
builder.Services.AddScoped<IScopedRandomService, RandomService>();
builder.Services.AddTransient<ITransientRandomService, RandomService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapClientEndpoints()
   .MapRandomEndpoints();

app.Run();

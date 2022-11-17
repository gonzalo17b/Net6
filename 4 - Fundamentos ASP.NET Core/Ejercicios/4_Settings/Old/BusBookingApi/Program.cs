using BusBookingApi.Clientes;
using BusBookingApi.Extensions;
using BusBookingApi.Middelwares;
using BusBookingApi.Random;
using BusBookingApi.Random.Interfaces;
using BusBookingApi.Services;
using BusBookingApi.Settings;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ISingeltonRandomService, RandomService>();
builder.Services.AddScoped<IScopedRandomService, RandomService>();
builder.Services.AddTransient<ITransientRandomService, RandomService>();
builder.Services.AddSingleton<EndpointLoginService>();

var app = builder.Build();
app.UseMiddleware<EndpointLoggerMiddleware>();

app.MapGet("/", () => "Hello World!");

app.MapClientEndpoints()
   .MapRandomEndpoints()
   .MapSettingEndpoints()
   .MapLogEndpoints();

app.Run();

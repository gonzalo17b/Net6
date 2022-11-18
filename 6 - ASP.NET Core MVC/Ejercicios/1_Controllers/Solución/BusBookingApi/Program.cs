using BusBookingApi.Clientes;
using BusBookingApi.Extensions;
using BusBookingApi.Middelwares;
using BusBookingApi.Random;
using BusBookingApi.Random.Interfaces;
using BusBookingApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IClientesService, ClientesService>();
builder.Services.AddSingleton<ISingeltonRandomService, RandomService>();
builder.Services.AddScoped<IScopedRandomService, RandomService>();
builder.Services.AddTransient<ITransientRandomService, RandomService>();
builder.Services.AddSingleton<EndpointLoginService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();
app.UseMiddleware<EndpointLoggerMiddleware>();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");
app.MapRandomEndpoints()
   .MapSettingEndpoints()
   .MapLogEndpoints();

app.Run();

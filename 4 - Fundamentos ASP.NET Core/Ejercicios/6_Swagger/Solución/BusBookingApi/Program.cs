using BusBookingApi.Clientes;
using BusBookingApi.Middlewares;
using BusBookingApi.Random;
using BusBookingApi.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<EndpointLoggingService>();
builder.Services.AddSingleton<ISingletonRandomService, RandomService>();
builder.Services.AddScoped<IScopedRandomService, RandomService>();
builder.Services.AddTransient<ITransientRandomService, RandomService>();
builder.Services.AddSingleton<IClientsService, ClientsService>();
builder.Services.Configure<Settings>(builder.Configuration.GetSection("ProyectSettings"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCustomExceptionHandler();
app.UseMiddleware<EndpointLoggerMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.MapGet("/logscounter", (EndpointLoggingService endpointLoggingService) => endpointLoggingService.GetElements());

app.MapGet("/settings/initial", (IOptions<Settings> options) => new ExternalSettings(options.Value)).ExcludeFromDescription();
app.MapGet("/settings/current", (IOptionsSnapshot<Settings> options) => new ExternalSettings(options.Value)).ExcludeFromDescription();
app.MapGet("/settings/iconfiguration", (IConfiguration configuration) =>
{
    var section = configuration.GetSection("ProyectSettings");
    return new ExternalSettings(new Settings
    {
        Name = section.GetValue<string>("Name"),
        Version = section.GetValue<string>("Version"),
        Environment = section.GetValue<string>("Environment"),
        ExternalApiKey = section.GetValue<string>("ExternalApiKey"),
    });
}).ExcludeFromDescription();


app
    .MapRandomEndpoints()
    .MapClientEndpoints();

app.Run();

public class Settings
{
    public string Name { get; set; } = string.Empty;

    public string Version { get; set; } = string.Empty;

    public string Environment { get; set; } = string.Empty;

    public string? ExternalApiKey { get; set; }
    public string? Message { get; set; }
}

public class ExternalSettings
{
    public ExternalSettings(Settings other)
    {
        Name = other.Name;
        Version = other.Version;
        Environment = other.Environment;
        ExternalApiConfigured = !string.IsNullOrEmpty(other.ExternalApiKey);
        Message = other.Message;
    }

    public string Name { get; set; } = string.Empty;

    public string Version { get; set; } = string.Empty;

    public string Environment { get; set; } = string.Empty;

    public bool ExternalApiConfigured { get; set; }
    public string? Message { get; set; }
}


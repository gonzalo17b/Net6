using BusBookingApi.Clientes;
using BusBookingApi.Middlewares;
using BusBookingApi.Random;
using BusBookingApi.Services;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BusBookingApi.Infrastructure.BusBookingApiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddSingleton<EndpointLoggingService>();
builder.Services.AddSingleton<ISingletonRandomService, RandomService>();
builder.Services.AddScoped<IScopedRandomService, RandomService>();
builder.Services.AddTransient<ITransientRandomService, RandomService>();
builder.Services.AddSingleton<IClientsService, ClientsService>();
builder.Services.Configure<Settings>(builder.Configuration.GetSection("ProyectSettings"));

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerGenOptions>();
builder.Services.AddApiVersioning();
builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BusBookingApi.Infrastructure.BusBookingApiDbContext>();
    await dbContext.Database.MigrateAsync();
}

app.UseCustomExceptionHandler();
app.UseMiddleware<EndpointLoggerMiddleware>();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    foreach (var version in apiVersionDescriptionProvider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint($"/swagger/{version.GroupName}/swagger.json", version.GroupName);
    }
});

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


app.MapRandomEndpoints()
    .MapClientEndpoints()
    .MapControllers();

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

public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;

    public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
    {
        _apiVersionDescriptionProvider = apiVersionDescriptionProvider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var version in _apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(version.GroupName, new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Bus Booking Api",
                Version = version.GroupName
            });
        }
    }
}
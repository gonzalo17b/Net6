using Microsoft.AspNetCore.Builder;
using OrderApp.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices();

var app = builder.Build();

app.UseApi()
   .UseRouting()
   .UseEndpoints(endpoints => endpoints.MapApiEndpoints());

app.Run();

public partial class Program { }
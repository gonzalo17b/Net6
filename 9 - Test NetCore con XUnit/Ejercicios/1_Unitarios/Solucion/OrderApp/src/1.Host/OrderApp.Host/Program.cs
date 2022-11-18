using OrderApp.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen()
                .ConfigureServices();

var app = builder.Build();

app.UseSwagger()
   .UseSwaggerUI();

app.UseApi()
   .UseRouting()
   .UseEndpoints(endpoints => endpoints.MapApiEndpoints());

app.Run();

using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrderApp.Api.Infrastructure;
using OrderApp.Services.Contracts;
using OrderApp.Services.MemoryServices;
using System.Reflection;

namespace OrderApp.Api
{
    public static class ApiConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services) 
        {
            services.AddSingleton<ICustomerService, CustomersMemoryService>()
                    .AddSingleton<IProductsService, ProductsMemoryService>()
                    .ConfigureOptions<ProblemDetailsOptionsCustomSetup>()
                    .AddProblemDetails()
                    .AddControllers()
                    .AddApplicationPart(typeof(ApiConfiguration).GetTypeInfo().Assembly)
                    .AddControllersAsServices();
        }

        public static WebApplication UseApi(this WebApplication app)
        {
            app.UseProblemDetails();

            return app;
        }

        public static ControllerActionEndpointConventionBuilder MapApiEndpoints(this IEndpointRouteBuilder endpoints)
        {
            return endpoints.MapControllers();
        }
    }
}

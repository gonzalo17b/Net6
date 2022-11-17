using BusBookingApi.Services;

namespace BusBookingApi.Extensions
{
    public static class LogMapEndpointExtenions
    {
        public static WebApplication MapLogEndpoints(this WebApplication app)
        {
            app.MapGet("/logCounter", (EndpointLoginService endpointService) =>
            {
                return endpointService.GetElements();
            });
            return app;
        }
    }
}

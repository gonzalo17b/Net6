using BusBookingApi.Services;

namespace BusBookingApi.Middelwares
{
    public class EndpointLoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public EndpointLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(
            HttpContext httpContext,
            EndpointLoginService loginService,
            ILogger<EndpointLoggerMiddleware> logger)
        {
            var path = httpContext.Request.Path;
            loginService.AddRequest(path);
            logger.LogInformation($"Se ha llamado al endpoint {path}");
            return _next.Invoke(httpContext);
        }
    }
}

namespace BusBookingApi.Middlewares
{
    using BusBookingApi.Services;

    public class EndpointLoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public EndpointLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, EndpointLoggingService endpointLoggingService, ILogger<EndpointLoggerMiddleware> logger)
        {
            endpointLoggingService.AddRequest(httpContext.Request.Path);
            logger.LogInformation($"Se ha llamado al endpoint {httpContext.Request.Path}");
            return _next(httpContext);
        }
    }
}



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

        public Task Invoke(HttpContext httpContext, EndpointLoggingService endpointLoggingService)
        {
            endpointLoggingService.AddRequest(httpContext.Request.Path);

            return _next(httpContext);
        }
    }
}

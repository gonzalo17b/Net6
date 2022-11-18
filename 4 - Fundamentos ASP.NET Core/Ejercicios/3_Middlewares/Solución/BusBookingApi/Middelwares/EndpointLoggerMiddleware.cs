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

        public Task Invoke(HttpContext httpContext, EndpointLoginService loginService)
        {
            var path = httpContext.Request.Path;
            loginService.AddRequest(path);
            return _next.Invoke(httpContext);
        }
    }
}

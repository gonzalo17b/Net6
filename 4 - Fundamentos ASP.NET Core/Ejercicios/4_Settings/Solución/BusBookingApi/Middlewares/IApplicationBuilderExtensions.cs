namespace BusBookingApi.Middlewares
{
    using BusBookingApi.Exceptions;

    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            return app.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                catch (EntityAlreadyExistingException e)
                {
                    context.Response.StatusCode = StatusCodes.Status409Conflict;
                    await context.Response.WriteAsync(e.Message);
                }
                catch (EntityNotFoundException e)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync(e.Message);
                }
            });
        }
    }
}

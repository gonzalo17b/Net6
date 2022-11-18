namespace BusBookingApi.Random
{
    public static class RandomEndpointExtensions
    {
        public static WebApplication MapRandomEndpoints(this WebApplication app)
        {
            app.MapGet("/random/serverInstance", (ISingletonRandomService randomService) =>
            {
                return new RandomData { Number1 = randomService.GetRandomNumber(), Number2 = randomService.GetRandomNumber() };
            });
            app.MapGet("/random/requestInstance", (IScopedRandomService randomService1, IScopedRandomService randomService2) =>
            {
                return new RandomData { Number1 = randomService1.GetRandomNumber(), Number2 = randomService2.GetRandomNumber() };
            });
            app.MapGet("/random/transientInstance", (ITransientRandomService randomService1, ITransientRandomService randomService2) =>
            {
                return new RandomData { Number1 = randomService1.GetRandomNumber(), Number2 = randomService2.GetRandomNumber() };
            });

            return app;
        }
    }
}

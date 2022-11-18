using BusBookingApi.Extensions;
using BusBookingApi.Random.Interfaces;

namespace BusBookingApi.Random
{
    public static class RandomEndpointExtensions
    {
        public static WebApplication MapRandomEndpoints(this WebApplication app)
        {
            app.MapGet("/random/singleton", (ISingeltonRandomService randomService) =>
            {
                return new RandomDto
                {
                    Number1 = randomService.GetRandom(),
                    Number2 = randomService.GetRandom()
                };
            });

            app.MapGet("/random/scoped", (IScopedRandomService randomService) =>
            {
                return new RandomDto
                {
                    Number1 = randomService.GetRandom(),
                    Number2 = randomService.GetRandom()
                };
            });

            app.MapGet("/random/trans", (ITransientRandomService randomService1, ITransientRandomService randomService2) =>
            {
                randomService1.PrintHash();
                randomService2.PrintHash();
                return new RandomDto
                {
                    Number1 = randomService1.GetRandom(),
                    Number2 = randomService2.GetRandom()
                };
            });

            return app;
        }
    }
}

using BusBookingApi.Random.Interfaces;

namespace BusBookingApi.Random
{
    public class RandomService: ISingeltonRandomService, IScopedRandomService, ITransientRandomService
    {
        private int _random;
        public RandomService()
        {
            Console.WriteLine($"Nueva instancia de {nameof(RandomService)}");
            var random = new System.Random();
            _random = random.Next(100);
        }

        public int GetRandom()
        {
            return _random;
        }
    }
}

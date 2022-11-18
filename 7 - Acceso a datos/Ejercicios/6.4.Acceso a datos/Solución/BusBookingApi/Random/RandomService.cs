namespace BusBookingApi.Random
{
    public interface ISingletonRandomService
    {
        int GetRandomNumber();
    }

    public interface IScopedRandomService
    {
        int GetRandomNumber();
    }

    public interface ITransientRandomService
    {
        int GetRandomNumber();
    }
    public class RandomService : ISingletonRandomService, IScopedRandomService, ITransientRandomService
    {
        private int _randomNumber;

        public RandomService()
        {
            System.Random random = new System.Random();
            _randomNumber = random.Next(100);
        }

        public int GetRandomNumber()
        {
            return _randomNumber;
        }
    }
}
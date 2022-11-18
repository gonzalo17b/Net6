namespace BusBookingApi.Extensions
{
    public static class ObjectExtensions
    {
        public static void PrintHash(this object obj)
        {
            Console.WriteLine(obj.GetHashCode().ToString());
        }
    }
}

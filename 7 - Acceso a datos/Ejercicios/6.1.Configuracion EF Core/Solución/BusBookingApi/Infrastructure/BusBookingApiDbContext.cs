namespace BusBookingApi.Infrastructure
{
    using Microsoft.EntityFrameworkCore;

    public class BusBookingApiDbContext : DbContext
    {
        public BusBookingApiDbContext(DbContextOptions<BusBookingApiDbContext> options)
            : base(options)
        {
        }
    }
}

using BookingSystem.dal.Entity;
using BookingSystem.dal.Interface;

namespace BookingSystem.dal.Implement
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(BookingSystemDbContext context) : base(context) { }

        public void Dispose()
        {
           // throw new NotImplementedException();
        }
    }
}

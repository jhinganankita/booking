using BookingSystem.dal.Entity;
using BookingSystem.dal.Interface;

namespace BookingSystem.dal.Implement
{
    public class BusesRepository : Repository<Buses>, IBusesRepository
    {
        public BusesRepository(BookingSystemDbContext context) : base(context) { }

        public void Dispose()
        {
           // throw new NotImplementedException();
        }
    }
}

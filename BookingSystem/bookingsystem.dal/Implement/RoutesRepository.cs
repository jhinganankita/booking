using BookingSystem.dal.Entity;
using BookingSystem.dal.Interface;

namespace BookingSystem.dal.Implement
{
    public class RoutesRepository : Repository<Routes>, IRoutesRepository
    {
        public RoutesRepository(BookingSystemDbContext context) : base(context) { }

        public void Dispose()
        {
           // throw new NotImplementedException();
        }
    }
}

using BookingSystem.dal.Entity;
using BookingSystem.dal.Interface;

namespace BookingSystem.dal.Implement
{
    public class PlaneSchedulesRepository : Repository<PlaneSchedules>, IPlaneSchedulesRepository
    {
        public PlaneSchedulesRepository(BookingSystemDbContext context) : base(context) { }

        public void Dispose()
        {
           // throw new NotImplementedException();
        }
    }
}

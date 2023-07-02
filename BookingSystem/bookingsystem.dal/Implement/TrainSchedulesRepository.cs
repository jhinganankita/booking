using BookingSystem.dal.Entity;
using BookingSystem.dal.Interface;

namespace BookingSystem.dal.Implement
{
    public class TrainSchedulesRepository : Repository<TrainSchedules>, ITrainSchedulesRepository
    {
        public TrainSchedulesRepository(BookingSystemDbContext context) : base(context) { }

        public void Dispose()
        {
           // throw new NotImplementedException();
        }
    }
}

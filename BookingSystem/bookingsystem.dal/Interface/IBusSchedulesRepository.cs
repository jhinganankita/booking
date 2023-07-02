using BookingSystem.dal.Entity;

namespace BookingSystem.dal.Interface
{
    public interface IBusSchedulesRepository : IRepository<BusSchedules>, IDisposable
    {
    }
}

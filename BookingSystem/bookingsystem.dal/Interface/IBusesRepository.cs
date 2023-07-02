using BookingSystem.dal.Entity;

namespace BookingSystem.dal.Interface
{
    public interface IBusesRepository : IRepository<Buses>, IDisposable
    {
    }
}

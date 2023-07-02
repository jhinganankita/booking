using BookingSystem.dal.Entity;

namespace BookingSystem.dal.Interface
{
    public interface ITrainsRepository : IRepository<Trains>, IDisposable
    {
    }
}

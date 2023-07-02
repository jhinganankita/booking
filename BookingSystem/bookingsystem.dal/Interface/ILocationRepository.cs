using BookingSystem.dal.Entity;

namespace BookingSystem.dal.Interface
{
    public interface ILocationRepository : IRepository<Location>, IDisposable
    {
    }
}

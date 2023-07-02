using BookingSystem.dal.Entity;

namespace BookingSystem.dal.Interface
{
    public interface ITicketsRepository : IRepository<Tickets>, IDisposable
    {
    }
}

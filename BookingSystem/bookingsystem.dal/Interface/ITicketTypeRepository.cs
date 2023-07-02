using BookingSystem.dal.Entity;

namespace BookingSystem.dal.Interface
{
    public interface ITicketTypeRepository : IRepository<TicketType>, IDisposable
    {
    }
}

using BookingSystem.dal.Entity;
using BookingSystem.dal.Interface;

namespace BookingSystem.dal.Implement
{
    public class UserRepository : Repository<Users>, IUserRepository
    {
        public UserRepository(BookingSystemDbContext context) : base(context)
        {
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}

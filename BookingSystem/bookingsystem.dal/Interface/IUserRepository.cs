using BookingSystem.dal.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.dal.Interface
{
    public interface IUserRepository : IRepository<Users>, IDisposable
    {
    }
}

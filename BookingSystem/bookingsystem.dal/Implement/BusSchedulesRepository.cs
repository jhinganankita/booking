using BookingSystem.dal.Entity;
using BookingSystem.dal.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookingSystem.dal.Implement
{
    public class BusSchedulesRepository : Repository<BusSchedules>, IBusSchedulesRepository
    {
        public BusSchedulesRepository(BookingSystemDbContext context) : base(context) { }

        public void Dispose()
        {
           // throw new NotImplementedException();
        }

       
    }
}

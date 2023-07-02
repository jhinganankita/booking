using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.dal.Interface
{
    public interface IRepository<T>
    {
        public Task AddAsync(T entity);
        public Task<T> GetById(object id);

        public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        public Task<IEnumerable<T>> GetAllAsync();
   
        public Task CommitAsync();
    }
}

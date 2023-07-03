using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.dal.Interface;
using System.Collections;

namespace BookingSystem.dal.Implement
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        internal BookingSystemDbContext dbContext;
        internal DbSet<T> dbSet;

        public Repository(BookingSystemDbContext context)
        {
            this.dbContext = context;
            dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task CommitAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = dbSet.AsQueryable();

            foreach (var includeExpression in includes)
            {
                query = query.Include(includeExpression);
            }

            return await query.ToListAsync();
            
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            var query = dbSet.AsQueryable();

            foreach (var includeExpression in includes)
            {
                query = query.Include(includeExpression);
            }

            return await query.Where(filter).ToListAsync();
        }


    }
}

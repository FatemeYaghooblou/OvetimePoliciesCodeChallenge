
using Core.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastracture.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public AppDbContext _dbContext;
        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;

        }

        public async Task DeleteAsync(int id)
        {
            var y = GetByIdAsync(id).Result;
            _dbContext.Set<T>().Remove(y);
            await _dbContext.SaveChangesAsync();
        }

      
        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            var query = _dbContext.Set<T>().Where(predicate);
            var t = await query.ToListAsync();

            try
            {
                return t;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var t = await _dbContext.Set<T>().FindAsync(id);
            if (t == null)
            {
                throw new Exception("Entity not found");
            }
            return t;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }


}

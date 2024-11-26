using Domain.Interfaces;
using Infrastructure.Databases;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MySqlDatabase _database;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(MySqlDatabase database)
        {
            _database = database;
            _dbSet = _database.Set<T>();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _database.SaveChangesAsync();
            return entity;
        }
        public Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return _database.SaveChangesAsync();
        }

        public Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return _database.SaveChangesAsync();
        }
    }
}

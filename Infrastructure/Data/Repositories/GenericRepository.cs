using Domain.Interfaces;
using Infrastructure.Databases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MySqlDatabase _database;
        private readonly DbSet<T> _dbSet;
        private readonly ILogger<GenericRepository<T>> _logger;

        public GenericRepository(MySqlDatabase database, ILogger<GenericRepository<T>> logger)
        {
            _logger = logger;
            _database = database;
            _dbSet = _database.Set<T>();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _database.FindAsync<T>(id);

            if (entity == null)
            {
                _logger.LogWarning("Entity with id: {Id} not found", id);
            }
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await _dbSet.ToListAsync();
            if (!entities.Any())
            {
                _logger.LogWarning("No entities found");
            }
            else
            {
                _logger.LogInformation("Retrieved {Count} entities", entities.Count);
            }
            return entities;
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            var entities = await _dbSet.Where(expression).ToListAsync();
            if (!entities.Any())
            {
                _logger.LogWarning("No entities found for the given expression: {Expression}", expression);
            }
            else
            {
                _logger.LogInformation("Found {Count} entities for the given expression: {Expression}", entities.Count, expression);
            }
            return entities;
        }

        public async Task<T> AddAsync(T entity)
        {
            _logger.LogInformation("Adding entity: {Entity}", entity);
            await _dbSet.AddAsync(entity);
            await _database.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _logger.LogInformation("Updating entity: {Entity}", entity);
            _dbSet.Update(entity);
            await _database.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _logger.LogInformation("Deleting entity: {Entity}", entity);
            _dbSet.Remove(entity);
            await _database.SaveChangesAsync();
            return entity;
        }
    }
}

using Domain.Interfaces;
using Infrastructure.Databases;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MySqlDatabase _database;

        public UnitOfWork(MySqlDatabase database)
        {   
            _database = database;
        }
        public IGenericRepository<T> Repository<T>() where T : class
        {
            return new GenericRepository<T>(_database);
        }
        public async Task SaveAsync()
        {
            await _database.SaveChangesAsync();
        }
        public void Dispose()
        {
            _database.Dispose();
        }
    }
}

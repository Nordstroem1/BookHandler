using System;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Data.Caching
{
    public class MemoryCacheService : ICacheMemoryService
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<T> GetAsync<T>(string cacheKey)
        {
            if (_memoryCache.TryGetValue(cacheKey, out var value))
            {
                return Task.FromResult((T)value);
            }

            return Task.FromResult(default(T));
        }

        public Task SetAsync<T>(string cacheKey, T value, TimeSpan expiration)
        {
            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration
            };

            _memoryCache.Set(cacheKey, value, options);
            return Task.CompletedTask;
        }
    }
}

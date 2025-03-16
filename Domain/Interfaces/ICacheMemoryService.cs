namespace Domain.Interfaces
{
    public interface ICacheMemoryService
    {
        Task<T> GetAsync<T>(string cacheKey);
        Task SetAsync<T>(string cacheKey, T value, TimeSpan expiration);
    }
}

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //other repositories
        Task SaveAsync();
    }
}

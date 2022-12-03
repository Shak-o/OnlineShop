using Microsoft.EntityFrameworkCore.Infrastructure;

namespace OnlineShop.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken);
        DatabaseFacade Database { get; }
    }
}

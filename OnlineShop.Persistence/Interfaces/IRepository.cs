using OnlineShop.Domain;
using System.Linq.Expressions;

namespace OnlineShop.Persistence.Interfaces
{
    public interface IRepository<T> where T : class, IBaseModel, IDisposable
    {
        Task<T> GetFirstAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default, params string[] includeProperties);
        T GetFirst(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default, params string[] includeProperties);
        Task<List<T>> GetAsync(Expression<Func<T, bool>>? filter = null, CancellationToken cancellationToken = default,
            params string[] includeProperties);
        Task<List<T>> GetWithoutTrackingAsync(Expression<Func<T, bool>>? filter = null,
            CancellationToken cancellationToken = default, params string[] includeProperties);
        Task<T> GetFirstNoTrackingAsync(Expression<Func<T, bool>>? filter = null,
            CancellationToken cancellationToken = default);

        Task<T> GetFirstOrDefaultNoTrackingAsync(Expression<Func<T, bool>>? filter = null,
            CancellationToken cancellationToken = default);
        Task<List<T>> GetByPagesAsync(Expression<Func<T, bool>>? filter, int page, int count, CancellationToken cancellationToken, params string[] includeProperties);
        Task AddAsync(T obj, CancellationToken cancellationToken);
        Task UpdateAsync(T obj, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}

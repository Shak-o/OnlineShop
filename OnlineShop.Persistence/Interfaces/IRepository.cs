using OnlineShop.Domain;
using System.Linq.Expressions;

namespace OnlineShop.Persistence.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<T> GetFirstAsync(Expression<Func<T, bool>> filter, string[] includes, CancellationToken cancellationToken);
        Task AddAsync(T obj, CancellationToken cancellationToken);
        Task UpdateAsync(T obj, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}

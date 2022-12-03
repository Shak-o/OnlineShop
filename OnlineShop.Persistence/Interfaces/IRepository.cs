using System.Linq.Expressions;
using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Customers.Commands;

namespace OnlineShop.Persistence.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetFirstAsync(Expression<Func<T, bool>> filter, string[] includes, CancellationToken cancellationToken);
        Task AddAsync(T obj, CancellationToken cancellationToken);
        Task UpdateAsync(T obj, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}

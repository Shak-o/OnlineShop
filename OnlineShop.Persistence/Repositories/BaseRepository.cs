using Microsoft.EntityFrameworkCore;
using OnlineShop.Persistence.Interfaces;
using System.Linq.Expressions;

namespace OnlineShop.Persistence.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _table;
        private readonly IUnitOfWork _unitOfWork;

        public BaseRepository(ShopDbContext context)
        {
            _table = context.Set<T>();
            _unitOfWork = context;
        }

        public async Task<T> GetFirstAsync(Expression<Func<T, bool>> filter, string[] includes , CancellationToken cancellationToken)
        {
            var toreTurn = _table.Include(includes[0]).Where(filter);
            return await toreTurn.FirstAsync(cancellationToken);
        }

        public async Task AddAsync(T obj, CancellationToken cancellationToken)
        {
            await _table.AddAsync(obj, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public Task UpdateAsync(T obj, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

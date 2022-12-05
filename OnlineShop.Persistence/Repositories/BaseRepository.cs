using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain;
using OnlineShop.Persistence.Interfaces;
using System.Linq.Expressions;
using OnlineShop.Persistence.Helpers;

namespace OnlineShop.Persistence.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        private readonly DbSet<T> _table;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ShopDbContext _test;
        public BaseRepository(ShopDbContext context, IMapper mapper)
        {
            _test = context;
            _table = context.Set<T>();
            _unitOfWork = context;
            _mapper = mapper;
        }

        public async Task<T> GetFirstAsync(Expression<Func<T, bool>> filter, string[] includes, CancellationToken cancellationToken)
        {
            var toreTurn = _table.Include(includes[0]).Where(filter);
            return await toreTurn.FirstAsync(cancellationToken);
        }

        public IQueryable<T> GetAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken, string[]? includes = null)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return _table.Where(filter);
        }

        public async Task AddAsync(T obj, CancellationToken cancellationToken)
        {
            try
            {
                await _table.AddAsync(obj, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during saving object {nameof(T)}. Exception: {ex.Message}");
            }

        }

        public async Task UpdateAsync(T obj, CancellationToken cancellationToken)
        {
            try
            {
                var check = await _table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == obj.Id, cancellationToken);

                if (check is null)
                    throw new Exception("Error during updating entity");

                check = ComparisonHelper.MapDiff(check, obj);

                _table.Update(check);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                throw new Exception($"Error during update, Id:{obj.Id} Error: {ex.Message}");
            }
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                var toRemove = await _table.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

                if (toRemove is null)
                    throw new Exception("Not found");

                _table.Remove(toRemove);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error happened during update. Error:{ex.Message}");
            }
        }
    }
}

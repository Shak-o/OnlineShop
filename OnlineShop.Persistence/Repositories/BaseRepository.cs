using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain;
using OnlineShop.Persistence.Interfaces;
using System.Linq.Expressions;

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

            var toreTurn = _table.Include("CustomerAddresses").Where(filter);
            return await toreTurn.FirstAsync(cancellationToken);
        }

        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken, params string[] includeProperties)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                var toreTurn = await _table.Where(filter).ToListAsync(cancellationToken);

                foreach (var item in toreTurn)
                {
                    foreach (var prop in includeProperties)
                    {
                        await _test.Entry(item).Collection(prop).LoadAsync(cancellationToken);
                    }
                }

                return toreTurn;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<T>> GetByPagesAsync(Expression<Func<T, bool>> filter, int page, int count, CancellationToken cancellationToken, params string[] includeProperties)
        {
            try
            {
                var max = _table.Count();
                var maxPages = max / count;
                var startIndex = page * count > max ? max - (max - (maxPages * count)) : page * count;
                var takeCount = (page + 1) * count > max ? max - maxPages * count : count;

                cancellationToken.ThrowIfCancellationRequested();

                var toreTurn = await _table
                    .Where(filter)
                    .OrderBy(x => x.Id)
                    .Skip(startIndex)
                    .Take(takeCount)
                    .ToListAsync(cancellationToken);

                foreach (var item in toreTurn)
                {
                    foreach (var prop in includeProperties)
                    {
                        await _test.Entry(item).Collection(prop).LoadAsync(cancellationToken);
                    }
                }

                return toreTurn;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ex: {ex.Message}");
            }
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
                var prop = check.GetType().GetProperty("Rowguid");
                var rowGuid = prop.GetValue(check);

                if (check is null)
                    throw new Exception("Error during updating entity");

                check = _mapper.Map(obj, check);

                prop.SetValue(check, rowGuid);

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

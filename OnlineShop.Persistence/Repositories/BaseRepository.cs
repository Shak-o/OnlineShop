using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain;
using OnlineShop.Domain.ProductCategories.Queries;
using OnlineShop.Persistence.Interfaces;
using System.Collections;
using System.Linq.Expressions;
using System.Threading;

namespace OnlineShop.Persistence.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, IBaseModel, IDisposable
    {
        private readonly DbSet<T> _table;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ShopDbContext _context;

        public BaseRepository(ShopDbContext context, IMapper mapper)
        {
            _context = context;
            _table = context.Set<T>();
            _unitOfWork = context;
            _mapper = mapper;
        }

        public async Task<T> GetFirstAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default, params string[] includeProperties)
        {

            cancellationToken.ThrowIfCancellationRequested();

            var toreTurn = _table.Where(filter);

            if (!toreTurn.Any())
            {
                throw new Exception("Not found");
            }

            if (includeProperties is not null)
                await IncludeProperties(toreTurn, includeProperties, cancellationToken);

            return await toreTurn.FirstAsync(cancellationToken);
        }

        public T GetFirst(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default, params string[] includeProperties)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var toreTurn = _table.Where(filter);

            if (!toreTurn.Any())
            {
                throw new Exception("Not found");
            }

            foreach (var item in toreTurn)
            {
                foreach (var prop in includeProperties)
                {
                    var check = toreTurn.First();
                    var property = typeof(T).GetProperty(prop);
                    var typeToCheck = property!.GetValue(check);

                    if (typeToCheck is IEnumerable or ICollection)
                        _context.Entry(item).Collection(prop).Load();
                    else
                        _context.Entry(item).Reference(prop).Load();
                }
            }

            return toreTurn.First();
        }

        public async Task<List<T>> GetAsync(Expression<Func<T, bool>>? filter = null, CancellationToken cancellationToken = default, params string[] includeProperties)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                var toreTurn = _table;

                if (filter != null)
                    toreTurn.Where(filter);
                await IncludeProperties(toreTurn, includeProperties, cancellationToken);

                return await toreTurn.ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
        public async Task<T> GetFirstNoTrackingAsync(Expression<Func<T, bool>>? filter = null, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var toreTurn = _table.AsNoTracking().Where(filter);

            if (!toreTurn.Any())
            {
                throw new Exception("Not found");
            }

            return await toreTurn.AsNoTracking().FirstAsync(cancellationToken);
        }

        public async Task<T> GetFirstOrDefaultNoTrackingAsync(Expression<Func<T, bool>>? filter = null, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return await _table.AsNoTracking().FirstOrDefaultAsync(filter, cancellationToken);
        }

        public async Task<List<T>> GetWithoutTrackingAsync(Expression<Func<T, bool>>? filter = null, CancellationToken cancellationToken = default, params string[] includeProperties)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                var check = _table.AsQueryable();

                if (filter is not null)
                    check = check.Where(filter);

                return await check.AsNoTracking().ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<T>> GetByPagesAsync(Expression<Func<T, bool>>? filter, int page, int count, CancellationToken cancellationToken, params string[] includeProperties)
        {
            try
            {
                var max = _table.Count();
                var maxPages = max / count;
                var startIndex = page * count > max ? max - (max - (maxPages * count)) : page * count;
                var takeCount = (page + 1) * count > max ? max - maxPages * count : count;

                cancellationToken.ThrowIfCancellationRequested();

                var toreTurn = _table
                    .AsNoTracking()
                    .OrderBy(x => x.Id)
                    .Skip(startIndex)
                    .Take(takeCount);
                //.ToListAsync(cancellationToken);

                //await IncludeProperties(toreTurn, includeProperties, cancellationToken);

                if (filter is not null)
                    toreTurn = toreTurn.Where(filter);

                return await toreTurn.ToListAsync(cancellationToken);
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

        private async Task IncludeProperties(IQueryable<T> toreTurn, string[] includeProperties, CancellationToken cancellationToken)
        {
            foreach (var item in toreTurn)
            {
                foreach (var prop in includeProperties)
                {
                    var check = toreTurn.First();
                    var property = typeof(T).GetProperty(prop);
                    var typeToCheck = property!.GetValue(check);

                    if (typeToCheck is IEnumerable or ICollection)
                        await _context.Entry(item).Collection(prop).LoadAsync(cancellationToken);
                    else
                        await _context.Entry(item).Reference(prop).LoadAsync(cancellationToken);
                }
            }
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}

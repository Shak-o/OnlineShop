using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.ProductCategories;
using OnlineShop.Domain.ProductCategories.Queries;
using OnlineShop.Persistence.Interfaces;
using System.Linq.Expressions;
using OnlineShop.Domain.Products.Queries;

namespace OnlineShop.Persistence.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository, IDisposable
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public ProductCategoryRepository(ShopDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductCategoryListQueryResult>> GetProductCategoriesAsync(int count, int page)
        {
            try
            {
                var max = _context.ProductCategories.Count();
                var maxPages = max / count;
                var startIndex = page * count > max ? max - (max - (maxPages * count)) : page * count;
                var takeCount = (page + 1) * count > max ? max - maxPages * count : count;

                var toReturn = await _context.ProductCategories
                    .AsNoTracking()
                    .Skip(startIndex)
                    .Take(takeCount)
                    .Select(x => new ProductCategoryListQueryResult()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        ProductCount = x.Products.Count,
                        ModifiedDate = x.ModifiedDate
                    })
                    .ToListAsync();

                return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error happened in process of reading product categories: {ex.Message}");
            }
        }
        public async Task<ProductCategoryQueryResult> GetOneProductCategory(int id)
        {
            try
            {
                var toReturn = await _context.ProductCategories
                    .AsNoTracking()
                    .Where(x => x.Id == id)
                    .Select(x => new ProductCategoryQueryResult
                    {
                        Id = x.Id,
                        ParentProductCategoryId = x.ParentProductCategoryId,
                        Name = x.Name,
                        ModifiedDate = x.ModifiedDate,
                        ParentProductCategory = _mapper.Map<ProductCategoryQueryResult>(x.ParentProductCategory),
                        ProductCount = x.Products.Count
                    })
                    .FirstAsync();

                return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error happened in process of reading product categories: {ex.Message}");
            }
        }

        public async Task DeleteProductCategoryAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                var toRemove = await _context.ProductCategories.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

                if (toRemove is null)
                    throw new Exception("Not found");

                if (_context.ProductCategories.Any(x => x.ParentProductCategoryId == toRemove.Id))
                    return;

                if (toRemove.ParentProductCategory is not null)
                    _context.ProductCategories.Entry(toRemove.ParentProductCategory).State = EntityState.Unchanged;

                _context.ProductCategories.Remove(toRemove);

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error happened during update. Error:{ex.Message}");
            }
        }
    }
}

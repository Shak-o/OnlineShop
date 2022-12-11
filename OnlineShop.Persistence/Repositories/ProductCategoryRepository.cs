using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.ProductCategories;
using OnlineShop.Domain.ProductCategories.Queries;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.Persistence.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository, IDisposable
    {
        private readonly ShopDbContext _context;

        public ProductCategoryRepository(ShopDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
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
                    .Skip(startIndex)
                    .Take(takeCount)
                    .Select(x => new ProductCategoryListQueryResult()
                    {
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
    }
}

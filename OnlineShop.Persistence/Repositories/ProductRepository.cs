using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Products;
using OnlineShop.Domain.Products.Queries;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly IMapper _mapper;
        private readonly ShopDbContext _context;

        public ProductRepository(ShopDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task UpdateProductAsync(Product product, CancellationToken cancellationToken)
        {
            try
            {
                var toUpdate = await _context.Products.AsNoTracking().FirstAsync(x => x.Id == product.Id, cancellationToken: cancellationToken);
                var map = _mapper.Map(product, toUpdate);

                map.Rowguid = toUpdate.Rowguid;
                map.ModifiedDate = DateTime.Now;
                map.ProductCategory.Id = int.Parse(product.ProductCategoryId.ToString());
                map.ProductModel.Id = int.Parse(product.ProductModelId.ToString());

                if (map.ProductCategory is not null)
                    _context.ProductCategories.Entry(map.ProductCategory).State = EntityState.Unchanged;

                if (map.ProductModel is not null)
                    _context.ProductModels.Entry(map.ProductModel).State = EntityState.Unchanged;

                _context.Products.Update(map);

                await _context.SaveEntitiesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public bool CheckOnDelete(int id)
        {
            var count = _context.SalesOrderDetails.Count(x => x.ProductId == id);

            return count == 0;
        }

        public async Task<List<ProductQueryResult>> GetAllProductsAsync(int page, int count)
        {
            try
            {
                var max = _context.ProductCategories.Count();
                var maxPages = max / count;
                var startIndex = page * count > max ? max - (max - (maxPages * count)) : page * count;
                var takeCount = (page + 1) * count > max ? max - maxPages * count : count;

                var toReturn = await _context.Products
                    .AsNoTracking()
                    .Skip(startIndex)
                    .Take(takeCount)
                    .Select(x => new ProductQueryResult
                    {
                        Id = x.Id,
                        Name = x.Name,
                        ProductNumber = x.ProductNumber,
                        Color = x.Color,
                        StandardCost = x.StandardCost,
                        ListPrice = x.ListPrice,
                        Size = x.Size,
                        Weight = x.Weight,
                        ProductCategoryId = x.ProductCategoryId,
                        ProductModelId = x.ProductModelId,
                        SellStartDate = x.SellStartDate,
                        SellEndDate = x.SellEndDate,
                        DiscontinuedDate = x.DiscontinuedDate,
                        ThumbNailPhoto = x.ThumbNailPhoto,
                        ThumbNailPhotoBase64 = Convert.ToBase64String(x.ThumbNailPhoto),
                        OrderCount = x.SalesOrderDetails.Count
                    })
                    .ToListAsync();

                return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error happened in process of reading product: {ex.Message}");
            }
        }
    }
}

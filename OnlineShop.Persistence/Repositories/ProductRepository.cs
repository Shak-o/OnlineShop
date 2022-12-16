using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Products;
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
    }
}

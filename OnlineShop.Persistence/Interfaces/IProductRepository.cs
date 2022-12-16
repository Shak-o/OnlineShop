using OnlineShop.Domain.Products;

namespace OnlineShop.Persistence.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task UpdateProductAsync(Product product, CancellationToken cancellationToken);
    }
}

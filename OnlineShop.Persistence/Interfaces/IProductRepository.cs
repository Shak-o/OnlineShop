using OnlineShop.Domain.Products;
using OnlineShop.Domain.Products.Queries;

namespace OnlineShop.Persistence.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task UpdateProductAsync(Product product, CancellationToken cancellationToken);
        bool CheckOnDelete(int id);
        Task<List<ProductQueryResult>> GetAllProductsAsync(int count, int page);
    }
}

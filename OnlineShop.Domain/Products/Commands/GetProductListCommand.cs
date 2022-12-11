using OnlineShop.Domain.ProductCategories;
using OnlineShop.Domain.Products.Queries;
using System.Linq.Expressions;
using MediatR;

namespace OnlineShop.Domain.Products.Commands
{
    public class GetProductListCommand : IRequest<List<ProductQueryResult>>
    {
        public int Page { get; set; }
        public Expression<Func<Product, bool>> Filter { get; set; }
        public string[] Includes { get; set; }
    }
}

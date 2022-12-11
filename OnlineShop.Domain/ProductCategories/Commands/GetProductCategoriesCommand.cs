using System.Linq.Expressions;
using MediatR;
using OnlineShop.Domain.ProductCategories.Queries;

namespace OnlineShop.Domain.ProductCategories.Commands
{
    public class GetProductCategoriesCommand : IRequest<List<ProductCategoryListQueryResult>>
    {
        public int Page { get; set; }
        public Expression<Func<ProductCategory, bool>> Filter { get; set; }
        public string[] Includes { get; set; }
    }
}

using MediatR;
using OnlineShop.Domain.ProductCategories.Queries;

namespace OnlineShop.Domain.ProductCategories.Commands
{
    public class GetProductCategoryCommand : IRequest<ProductCategoryQueryResult>
    {
        public int Id { get; set; }
    }
}

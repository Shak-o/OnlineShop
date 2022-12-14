using MediatR;
using OnlineShop.Domain.ProductCategories.Queries;

namespace OnlineShop.Domain.ProductCategories.Commands
{
    public class GetAllProductCategoriesCommand : IRequest<List<ProductCategoryQueryResult>>
    {
    }
}

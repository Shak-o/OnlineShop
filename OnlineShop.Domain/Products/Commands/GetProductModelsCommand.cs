using MediatR;
using OnlineShop.Domain.Products.Queries;

namespace OnlineShop.Domain.Products.Commands
{
    public class GetProductModelsCommand : IRequest<List<ProductModelQueryResult>>
    {
    }
}

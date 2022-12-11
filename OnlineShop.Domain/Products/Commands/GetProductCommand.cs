using MediatR;
using OnlineShop.Domain.Products.Queries;

namespace OnlineShop.Domain.Products.Commands
{
    public class GetProductCommand : IRequest<ProductQueryResult>
    {
        public int Id { get; set; }
    }
}

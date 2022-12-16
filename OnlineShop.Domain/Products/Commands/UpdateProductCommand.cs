using MediatR;
using OnlineShop.Domain.Products.Queries;

namespace OnlineShop.Domain.Products.Commands
{
    public class UpdateProductCommand : IRequest
    {
        public ProductQueryResult Product { get; set; }
    }
}

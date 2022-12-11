using MediatR;

namespace OnlineShop.Domain.Products.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}

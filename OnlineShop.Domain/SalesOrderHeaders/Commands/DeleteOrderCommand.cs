using MediatR;

namespace OnlineShop.Domain.SalesOrderHeaders.Commands
{
    public class DeleteOrderCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}

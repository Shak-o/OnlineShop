using MediatR;
using OnlineShop.Domain.SalesOrderHeaders.Queries;

namespace OnlineShop.Domain.SalesOrderHeaders.Commands
{
    public class UpdateOrderCommand : IRequest<Unit>
    {
        public OrderQueryResult Order { get; set; }
    }
}

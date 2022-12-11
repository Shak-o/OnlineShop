using MediatR;
using OnlineShop.Domain.SalesOrderHeaders.Queries;

namespace OnlineShop.Domain.SalesOrderHeaders.Commands
{
    public class GetOrderCommand : IRequest<OrderQueryResult>
    {
        public int Id { get; set; }
    }
}

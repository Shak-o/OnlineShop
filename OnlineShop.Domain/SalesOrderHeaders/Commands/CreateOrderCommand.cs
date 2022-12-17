using MediatR;
using OnlineShop.Domain.Addresses.Queries;
using OnlineShop.Domain.Customers.Queries;
using OnlineShop.Domain.SalesOrderHeaders.Queries;

namespace OnlineShop.Domain.SalesOrderHeaders.Commands
{
    public class CreateOrderCommand : IRequest
    {
      public OrderQueryResult Order { get; set; }
    }
}

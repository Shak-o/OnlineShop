using OnlineShop.Domain.Products;
using System.Linq.Expressions;
using MediatR;
using OnlineShop.Domain.SalesOrderHeaders.Queries;

namespace OnlineShop.Domain.SalesOrderHeaders.Commands
{
    public class GetOrderListCommand : IRequest<List<OrderListQueryResult>>
    {
        public int Page { get; set; }
        public Expression<Func<SalesOrderHeader, bool>> Filter { get; set; }
        public string[] Includes { get; set; }
    }
}

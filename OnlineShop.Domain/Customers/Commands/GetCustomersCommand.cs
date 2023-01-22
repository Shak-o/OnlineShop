using MediatR;
using OnlineShop.Domain.Customers.ResultModels;
using System.Linq.Expressions;

namespace OnlineShop.Domain.Customers.Commands
{
    public class GetCustomersCommand : IRequest<GetCustomersResult>
    {
        public int Page { get; set; }
        public Expression<Func<Customer, bool>> Filter { get; set; }
        public string[] Includes { get; set; }
    }
}

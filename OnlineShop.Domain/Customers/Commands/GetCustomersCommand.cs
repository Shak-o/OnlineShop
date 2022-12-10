using OnlineShop.Domain.Customers;
using System.Linq.Expressions;
using MediatR;
using OnlineShop.Domain.Customers.Queries;

namespace OnlineShop.Domain.Customers.Commands
{
    public class GetCustomersCommand : IRequest<List<CustomerQuery>>
    {
        public int Page { get; set; }
        public Expression<Func<Customer, bool>> Filter { get; set; }
        public string[] Includes { get; set; }
    }
}

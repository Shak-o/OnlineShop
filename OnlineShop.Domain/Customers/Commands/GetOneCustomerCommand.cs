using System.Linq.Expressions;
using MediatR;

namespace OnlineShop.Domain.Customers.Commands
{
    public class GetOneCustomerCommand : IRequest<Customer>
    {
        public Expression<Func<Customer, bool>> Filter { get; set; }
        public string[] Includes { get; set; }
    }
}

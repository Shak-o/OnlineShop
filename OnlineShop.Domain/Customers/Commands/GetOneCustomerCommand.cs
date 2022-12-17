using MediatR;
using OnlineShop.Domain.Customers.Queries;

namespace OnlineShop.Domain.Customers.Commands
{
    public class GetOneCustomerCommand : IRequest<CustomerQuery>
    {
        public int Id { get; set; }
    }
}

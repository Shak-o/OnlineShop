using MediatR;

namespace OnlineShop.Domain.Customers.Commands
{
    public class DeleteCustomerCommand : IRequest
    {
        public int Id { get; set; }
    }
}

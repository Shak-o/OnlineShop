using MediatR;

namespace OnlineShop.Domain.Accounts.Commands
{
    public class CheckCustomerByEmailCommand : IRequest<bool>
    {
        public string Email { get; set; }
    }
}

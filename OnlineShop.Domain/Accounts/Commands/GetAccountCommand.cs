using OnlineShop.Domain.Addresses;
using System.Linq.Expressions;
using MediatR;

namespace OnlineShop.Domain.Accounts.Commands
{
    public class GetAccountCommand : IRequest<Account>
    {
        public Expression<Func<Account, bool>> Filter { get; set; }
    }
}

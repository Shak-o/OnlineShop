using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Accounts;
using OnlineShop.Domain.Accounts.Commands;
using OnlineShop.Persistence;

namespace OnlineShop.App.CommandHandlers.Accounts
{
    public class GetAccountCommandHandler : IRequestHandler<GetAccountCommand, Account>
    {
        private readonly ShopDbContext _context;

        public GetAccountCommandHandler(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<Account> Handle(GetAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.Accounts.AsNoTracking().FirstAsync(request.Filter, cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during accounts get: {ex.Message}");
            }
        }
    }
}

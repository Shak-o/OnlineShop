using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Accounts.Commands;
using OnlineShop.Persistence;

namespace OnlineShop.App.CommandHandlers.Accounts
{
    public class CheckCustomerByEmailCommandHandler : IRequestHandler<CheckCustomerByEmailCommand, bool>
    {
        private readonly ShopDbContext _context;

        public CheckCustomerByEmailCommandHandler(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CheckCustomerByEmailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Accounts.AnyAsync(x => x.Email == request.Email, cancellationToken);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

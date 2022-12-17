using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Accounts;
using OnlineShop.Domain.Accounts.Commands;
using OnlineShop.Domain.Customers;
using OnlineShop.Persistence;

namespace OnlineShop.App.CommandHandlers.Accounts
{
    public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand>
    {
        private readonly UserManager<Account> _userManager;
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public UpdateAccountCommandHandler(UserManager<Account> userManager, ShopDbContext context, IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var customer = await _context.Customers.FirstAsync(x => x.Id == request.CustomerId, cancellationToken);
                var account = await _userManager.FindByIdAsync(customer.AccountId);

                var test = _userManager.PasswordHasher.HashPassword(account, request.Password);
                
                account.PasswordHash = test;
                account.Email = request.Email;
                account.NormalizedEmail = request.Email.ToUpper();
                account.UserName = request.UserName;
                account.NormalizedUserName = request.UserName.ToUpper();

                await _userManager.UpdateAsync(account);

                var mapped = _mapper.Map<Customer>(request);
                _context.Customers.Update(mapped);
                await _context.SaveEntitiesAsync(cancellationToken);

                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}

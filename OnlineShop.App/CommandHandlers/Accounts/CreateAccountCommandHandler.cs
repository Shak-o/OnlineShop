using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Domain.Accounts;
using OnlineShop.Domain.Accounts.Commands;
using OnlineShop.Domain.Customers;
using OnlineShop.Persistence;

namespace OnlineShop.App.CommandHandlers.Accounts
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, (bool, IEnumerable<IdentityError>)>
    {
        private readonly ShopDbContext _context;
        private readonly SignInManager<Account> _signInManager;
        private readonly UserManager<Account> _userManager;

        public CreateAccountCommandHandler(ShopDbContext context, SignInManager<Account> signInManager, UserManager<Account> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<(bool, IEnumerable<IdentityError>)> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                if (_context.Customers.Any(x => x.EmailAddress == request.Email))
                    throw new Exception("Cannot create customer with duplicate email");

                var customer = new Customer
                {
                    NameStyle = request.NameStyle,
                    Title = request.Title,
                    FirstName = request.FirstName,
                    MiddleName = request.MiddleName,
                    LastName = request.LastName,
                    Suffix = request.Suffix,
                    CompanyName = request.CompanyName,
                    SalesPerson = request.SaleSperson,
                    EmailAddress = request.Email,
                    Phone = request.PhoneNumber,
                };
                await _context.Customers.AddAsync(customer, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                var user = new Account()
                {
                    CustomerId = customer.Id,
                    Email = request.Email,
                    NormalizedEmail = request.Email.ToUpper(),
                    UserName = request.UserName,
                    NormalizedUserName = request.UserName.ToUpper(),
                    PhoneNumber = request.PhoneNumber
                };

                var result = await _userManager.CreateAsync(user, request.Password);

                if (!result.Succeeded)
                    return (false, result.Errors);

                customer.AccountId = user.Id;
                _context.Update(customer);
                await _context.SaveChangesAsync(cancellationToken);

                await transaction.CommitAsync(cancellationToken);
                return (true, Array.Empty<IdentityError>());
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during account creation:{ex.Message}");
            }


        }
    }
}

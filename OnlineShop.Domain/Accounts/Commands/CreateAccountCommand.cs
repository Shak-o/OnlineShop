using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Domain.Models;

namespace OnlineShop.Domain.Accounts.Commands
{
    public class CreateAccountCommand : IRequest<(bool, IEnumerable<IdentityError>)>
    {
        public bool NameStyle {get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Suffix { get; set; }
        public string CompanyName { get; set; }
        public string SaleSperson { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }
    }
}

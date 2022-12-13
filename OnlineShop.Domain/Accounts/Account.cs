using Microsoft.AspNetCore.Identity;
using OnlineShop.Domain.Customers;

namespace OnlineShop.Domain.Accounts
{
    public class Account : IdentityUser
    {
        public int CustomerId { get; set; }
    }
}

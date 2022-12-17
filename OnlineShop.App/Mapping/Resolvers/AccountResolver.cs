using AutoMapper;
using AutoMapper.Execution;
using OnlineShop.Domain.Accounts;
using OnlineShop.Domain.Accounts.Commands;
using OnlineShop.Domain.Addresses;
using OnlineShop.Domain.Addresses.Queries;
using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Customers.Queries;
using OnlineShop.Domain.Models;

namespace OnlineShop.App.Mapping.Resolvers
{
    public class AccountResolver : IValueResolver<UpdateAccountCommand, Customer , List<CustomerAddress>>
    {
        public List<CustomerAddress> Resolve(UpdateAccountCommand source, Customer destination, List<CustomerAddress> destMember, ResolutionContext context)
        {
            var toReturn = source.Addresses.Select(x => new CustomerAddress(){CustomerId = source.CustomerId, AddressId = x.Id}).ToList();

            return toReturn;
        }
    }
}

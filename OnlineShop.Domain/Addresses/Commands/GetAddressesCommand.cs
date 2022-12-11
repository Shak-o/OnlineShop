using MediatR;
using OnlineShop.Domain.Addresses.Queries;
using OnlineShop.Domain.Customers;
using System.Linq.Expressions;

namespace OnlineShop.Domain.Addresses.Commands
{
    public class GetAddressesCommand : IRequest<List<AddressQuery>>
    {
        public int Page { get; set; }
        public Expression<Func<Address, bool>> Filter { get; set; }
        public string[] Includes { get; set; }
    }
}

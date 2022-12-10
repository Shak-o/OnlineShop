using MediatR;
using OnlineShop.Domain.Addresses.Queries;

namespace OnlineShop.Domain.Addresses.Commands
{
    public class GetAddressesCommand : IRequest<AddressQuery>
    {
        public int Page { get; set; }
        public Expression<Func<Customer, bool>> Filter { get; set; }
        public string[] Includes { get; set; }
    }
}

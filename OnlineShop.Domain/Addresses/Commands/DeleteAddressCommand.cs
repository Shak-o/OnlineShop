using MediatR;

namespace OnlineShop.Domain.Addresses.Commands
{
    public class DeleteAddressCommand : IRequest
    {
        public int Id { get; set; }
    }
}

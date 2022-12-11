using MediatR;
using OnlineShop.Domain.Addresses;
using OnlineShop.Domain.Addresses.Commands;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Addresses
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand>
    {
        private readonly IRepository<Address> _repository;

        public DeleteAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.DeleteAsync(request.Id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error happened during address deletion {ex.Message}");
            }

            return Unit.Value;
        }
    }
}

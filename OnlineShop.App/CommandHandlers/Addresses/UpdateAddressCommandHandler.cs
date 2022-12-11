using AutoMapper;
using MediatR;
using OnlineShop.Domain.Addresses;
using OnlineShop.Domain.Addresses.Commands;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Addresses
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public UpdateAddressCommandHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var convert = _mapper.Map<UpdateAddressCommand, Address>(request);
                await _repository.UpdateAsync(convert, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during address update: {ex.Message}");
            }

            return Unit.Value;
        }
    }
}

using AutoMapper;
using MediatR;
using OnlineShop.Domain.Addresses;
using OnlineShop.Domain.Addresses.Commands;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Addresses
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand>
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public CreateAddressCommandHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var convert = _mapper.Map<CreateAddressCommand, Address>(request);

                await _repository.AddAsync(convert, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during addition of address: {ex.Message}");
            }
            return Unit.Value;
        }
    }
}

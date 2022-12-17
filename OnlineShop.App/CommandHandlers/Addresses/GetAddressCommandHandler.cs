using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using OnlineShop.App.Options;
using OnlineShop.Domain.Addresses;
using OnlineShop.Domain.Addresses.Commands;
using OnlineShop.Domain.Addresses.Queries;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Addresses
{
    public class GetAddressCommandHandler : IRequestHandler<GetAddressesCommand, List<AddressQuery>>
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;
        private readonly IOptions<PagingOptions> _options;

        public GetAddressCommandHandler(IRepository<Address> repository, IMapper mapper, IOptions<PagingOptions> options)
        {
            _repository = repository;
            _mapper = mapper;
            _options = options;
        }

        public async Task<List<AddressQuery>> Handle(GetAddressesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.GetWithoutTrackingAsync(request.Filter, cancellationToken);

                var convert = _mapper.Map<List<Address>, List<AddressQuery>>(result);

                return convert;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during reading addresses:{ex.Message}");
            }
        }
    }
}

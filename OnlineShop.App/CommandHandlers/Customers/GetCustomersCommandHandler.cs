using MediatR;
using Microsoft.Extensions.Options;
using OnlineShop.App.Options;
using OnlineShop.Domain.Customers.Commands;
using OnlineShop.Domain.Customers.Queries;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Customers
{
    public class GetCustomersCommandHandler : IRequestHandler<GetCustomersCommand, List<CustomerQuery>>
    {
        private readonly ICustomerRepository _repository;
        private readonly IOptions<PagingOptions> _options;

        public GetCustomersCommandHandler(ICustomerRepository repository, IOptions<PagingOptions> options)
        {
            _repository = repository;
            _options = options;
        }

        public async Task<List<CustomerQuery>> Handle(GetCustomersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.GetCustomersAsync(request.Page, _options.Value.Count);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during get: {ex.Message}");
            }
        }
    }
}

using MediatR;
using Microsoft.Extensions.Options;
using OnlineShop.App.Options;
using OnlineShop.Domain.Customers.Commands;
using OnlineShop.Domain.Customers.ResultModels;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Customers
{
    public class GetCustomersCommandHandler : IRequestHandler<GetCustomersCommand, GetCustomersResult>
    {
        private readonly ICustomerRepository _repository;
        private readonly IOptions<PagingOptions> _options;

        public GetCustomersCommandHandler(ICustomerRepository repository, IOptions<PagingOptions> options)
        {
            _repository = repository;
            _options = options;
        }

        public async Task<GetCustomersResult> Handle(GetCustomersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.GetCustomersAsync(request.Page, _options.Value.Count);
                var toReturn = new GetCustomersResult() { Customers = result.Item2, MaxPages = result.Item1 };
                return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during get: {ex.Message}");
            }
        }
    }
}

using MediatR;
using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Customers.Commands;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Customers
{
    public class GetCustomersCommandHandler : IRequestHandler<GetCustomersCommand, List<Customer>>
    {
        private readonly IRepository<Customer> _repository;

        public GetCustomersCommandHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<List<Customer>> Handle(GetCustomersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.GetAsync(request.Filter, cancellationToken, request.Includes);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during get: {ex.Message}");
            }
        }
    }
}

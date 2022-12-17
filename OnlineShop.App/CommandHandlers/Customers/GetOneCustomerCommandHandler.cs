using MediatR;
using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Customers.Commands;
using OnlineShop.Domain.Customers.Queries;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Customers
{
    public class GetOneCustomerCommandHandler : IRequestHandler<GetOneCustomerCommand, CustomerQuery>
    {
        private readonly ICustomerRepository _repository;

        public GetOneCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomerQuery> Handle(GetOneCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.GetCustomerAsync(request.Id);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception($"Cant get customer: {ex.Message}");
            }
        }
    }
}

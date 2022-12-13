using MediatR;
using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Customers.Commands;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Customers
{
    public class GetOneCustomerCommandHandler : IRequestHandler<GetOneCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _repository;

        public GetOneCustomerCommandHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Customer> Handle(GetOneCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.GetFirstAsync(request.Filter, cancellationToken, request.Includes);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception($"Cant get customer: {ex.Message}");
            }
        }
    }
}

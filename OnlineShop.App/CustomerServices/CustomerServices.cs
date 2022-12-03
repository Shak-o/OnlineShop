using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Customers.Commands;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CustomerServices
{
    public class CustomerServices : ICustomerServices
    {
        private readonly IRepository<Customer> _repository;
        public CustomerServices(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task AddCustomerAsync(CreateCustomerCommand command, CancellationToken token)
        {

            //await _repository.AddAsync(command, token);
        }
    }
}

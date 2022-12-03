using OnlineShop.Domain.Customers.Commands;

namespace OnlineShop.App.CustomerServices
{
    public interface ICustomerServices
    {
        Task AddCustomerAsync(CreateCustomerCommand command, CancellationToken token);
    }
}

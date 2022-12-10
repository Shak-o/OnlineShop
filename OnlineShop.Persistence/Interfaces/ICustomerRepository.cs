using OnlineShop.Domain.Customers.Queries;

namespace OnlineShop.Persistence.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<CustomerQuery>> GetCustomersAsync(int page, int count);
    }
}

using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Customers.Queries;

namespace OnlineShop.Persistence.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<List<CustomerQuery>> GetCustomersAsync(int page, int count);
    }
}

using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Customers.Queries;

namespace OnlineShop.Persistence.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<(int, List<CustomerQuery>)> GetCustomersAsync(int page, int count);
        Task<CustomerQuery> GetCustomerAsync(int id);
    }
}

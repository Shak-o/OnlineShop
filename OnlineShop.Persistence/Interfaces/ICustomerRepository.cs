using OnlineShop.Domain.Customers.Queries;

namespace OnlineShop.Persistence.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<GetCustomerQuery>> GetCustomersAsync(int page, int count);
    }
}

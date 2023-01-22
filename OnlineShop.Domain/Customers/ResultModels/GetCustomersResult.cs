using OnlineShop.Domain.Customers.Queries;

namespace OnlineShop.Domain.Customers.ResultModels
{
    public class GetCustomersResult
    {
        public List<CustomerQuery> Customers { get; set; }
        public int MaxPages { get; set; }
    }
}

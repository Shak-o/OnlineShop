using OnlineShop.Domain.SalesOrderHeaders.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.SalesOrderHeaders;

namespace OnlineShop.Persistence.Interfaces
{
    public interface IOrdersRepository : IRepository<SalesOrderHeader>
    {
        Task<List<OrderListQueryResult>> GetSalesAsync(int page, int count);
        Task<OrderQueryResult> GetOrderAsync(int id);
    }
}

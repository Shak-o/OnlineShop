using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.Interfaces
{
    public interface IReportsRepository
    {
        Task<List<(int, decimal)>> GetReportByMont();
        Task<List<(int, decimal)>> GetReportByYear();
        Task<List<TopCustomers>> GetTopBySalesCustomer();
        Task<List<TopProduct>> GetTopBySalesProduct();
    }
}

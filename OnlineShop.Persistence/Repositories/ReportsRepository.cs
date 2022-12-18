using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineShop.Domain.Models;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.Persistence.Repositories
{
    public class ReportsRepository : IReportsRepository
    {
        private readonly ShopDbContext _context;
        private readonly ILogger<ReportsRepository> _logger;

        public ReportsRepository(ShopDbContext context, ILogger<ReportsRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<(int, decimal)>> GetReportByMont()
        {
            _logger.LogInformation("started");
            var secTry = _context.SalesOrderHeaders.Select(x => new { Tot = x.TotalDue, Ord = x.OrderDate.Month })
                .GroupBy(x => x.Ord);
            var toReturn = new List<(int, decimal)>();

            foreach (var item in secTry)
            {
                var key = item.Key;
                var sum = item.Sum(x => x.Tot);
                toReturn.Add((key, sum));
            }

            return toReturn;
        }

        public async Task<List<(int, decimal)>> GetReportByYear()
        {

            var secTry = _context.SalesOrderHeaders.Select(x => new { Tot = x.TotalDue, Ord = x.OrderDate.Year })
                .GroupBy(x => x.Ord);
            var toReturn = new List<(int, decimal)>();

            foreach (var item in secTry)
            {
                var key = item.Key;
                var sum = item.Sum(x => x.Tot);
                toReturn.Add((key, sum));
            }

            return toReturn;
        }

        public async Task<List<TopCustomers>> GetTopBySalesCustomer()
        {

            var secTry = _context.SalesOrderHeaders.Select(x => new { Tot = x.TotalDue, CustId = x.CustomerId })
                .GroupBy(x => x.CustId);
            
            var res = secTry
                .Select(x => new TopCustomers() { TotalCount = x.Sum(x => x.Tot), CustomerId = x.Key })
                .OrderByDescending(x => x.TotalCount)
                .Take(10)
                .ToList();

            return res;
        }

        public async Task<List<TopProduct>> GetTopBySalesProduct()
        {

            var secTry = _context.SalesOrderHeaders.Include(x => x.SalesOrderDetails)
                .Select(x => new { ProdId = x, CustId = x.CustomerId })
                .GroupBy(x => x.CustId);

            var fe = _context.SalesOrderDetails
                .Include(x => x.SalesOrder)
                .Select(x => new { ProdId = x.Id, Coun = x.SalesOrder.TotalDue })
                .GroupBy(x => x.ProdId);

            var res = fe
                .Select(x => new TopProduct() { Count = x.Sum(x => x.Coun), ProductId = x.Key })
                .OrderByDescending(x => x.Count)
                .Take(10)
                .ToList();

            return res;
        }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Addresses.Queries;
using OnlineShop.Domain.Customers.Queries;
using OnlineShop.Domain.Products.Queries;
using OnlineShop.Domain.SalesOrderHeaders;
using OnlineShop.Domain.SalesOrderHeaders.Queries;
using OnlineShop.Persistence.Interfaces;
using Exception = System.Exception;

namespace OnlineShop.Persistence.Repositories
{
    public class OrdersRepository : BaseRepository<SalesOrderHeader>, IOrdersRepository
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public OrdersRepository(ShopDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OrderListQueryResult>> GetSalesAsync(int page, int count)
        {
            try
            {
                var max = _context.ProductCategories.Count();
                var maxPages = max / count;
                var startIndex = page * count > max ? max - (max - (maxPages * count)) : page * count;
                var takeCount = (page + 1) * count > max ? max - maxPages * count : count;

                var toReturn = await _context.SalesOrderHeaders
                    .AsNoTracking()
                    .Skip(startIndex)
                    .Take(takeCount)
                    .Select(x => new OrderListQueryResult
                    {
                        Id = x.Id,
                        OrderDate = x.OrderDate,
                        DueDate = x.DueDate,
                        Status = x.Status,
                        CustomerId = x.CustomerId,
                        CustomerName = $"{x.Customer.FirstName} {x.Customer.LastName}",
                        ShipToAddressId = x.ShipToAddressId,
                        SubTotal = x.SubTotal,
                        TotalDue = x.TotalDue,
                        Comment = x.Comment,
                        ModifiedDate = x.ModifiedDate
                    })
                    .ToListAsync();

                return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error happened in process of reading product categories: {ex.Message}");
            }
        }

        public async Task<OrderQueryResult> GetOrderAsync(int id)
        {
            try
            {
                var toReturn = _context.SalesOrderHeaders
                    .AsNoTracking()
                    .Where(x => x.Id == id)
                    .Select(x => new OrderQueryResult
                    {
                        Id = x.Id,
                        RevisionNumber = x.RevisionNumber,
                        OrderDate = x.OrderDate,
                        DueDate = x.DueDate,
                        ShipDate = x.ShipDate,
                        Status = x.Status,
                        OnlineOrderFlag = x.OnlineOrderFlag,
                        AccountNumber = x.AccountNumber,
                        CustomerId = x.CustomerId,
                        ShipToAddressId = x.ShipToAddressId,
                        BillToAddressId = x.BillToAddressId,
                        ShipMethod = x.ShipMethod,
                        CreditCardApprovalCode = x.CreditCardApprovalCode,
                        SubTotal = x.SubTotal,
                        TaxAmt = x.TaxAmt,
                        Freight = x.Freight,
                        TotalDue = x.TotalDue,
                        Comment = x.Comment,
                        BillToAddress = _mapper.Map<AddressQuery>(x.BillToAddress),
                        Customer = _mapper.Map<CustomerQuery>(x.Customer),
                        SalesOrderDetails = _mapper.Map<List<SalesOrderDetailQueryResult>>(x.SalesOrderDetails),
                        ShipToAddress = _mapper.Map<AddressQuery>(x.ShipToAddress)
                    });

                return await toReturn.FirstAsync();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
           
        }
    }
}

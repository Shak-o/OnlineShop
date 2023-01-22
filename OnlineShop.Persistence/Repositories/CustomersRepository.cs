using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Addresses;
using OnlineShop.Domain.Addresses.Queries;
using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Customers.Queries;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.Persistence.Repositories
{
    public class CustomersRepository : BaseRepository<Customer>, ICustomerRepository, IDisposable
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public CustomersRepository(ShopDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<(int, List<CustomerQuery>)> GetCustomersAsync(int page, int count)
        {
            try
            {
                var max = _context.Customers.Count();
                var maxPages = max / count;
                var startIndex = page * count > max ? max - (max - (maxPages * count)) : page * count;
                var takeCount = (page + 1) * count > max ? max - maxPages * count : count;

                var toReturn = await _context.Customers
                    .Include(x => x.CustomerAddresses)
                    .ThenInclude(x => x.Address)
                    .OrderBy(x => x.Id)
                    .Skip(startIndex)
                    .Take(takeCount)
                    .Select(customer => new CustomerQuery()
                    {
                        Id = customer.Id,
                        CompanyName = customer.CompanyName,
                        EmailAddress = customer.EmailAddress,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Phone = customer.Phone,
                        NumberOfAddresses = customer.CustomerAddresses.Count,
                        Addresses = _mapper.Map<List<Address>, List<AddressQuery>>(customer.CustomerAddresses.Select(x => x.Address).ToList()),
                        Password = "******"
                    })
                    .ToListAsync();

                return (maxPages, toReturn);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<CustomerQuery> GetCustomerAsync(int id)
        {
            try
            {
                var toReturn = _context.Customers
                    .AsNoTracking()
                    .Where(x => x.Id == id)
                    .Select(x => new CustomerQuery
                    {
                        Id = x.Id,
                        AccountId = x.AccountId,
                        Title = x.Title,
                        FirstName = x.FirstName,
                        MiddleName = x.MiddleName,
                        Password = "*",
                        LastName = x.LastName,
                        Suffix = x.Suffix,
                        CompanyName = x.CompanyName,
                        SalesPerson = x.SalesPerson,
                        EmailAddress = x.EmailAddress,
                        Phone = x.Phone,
                        NumberOfAddresses = x.CustomerAddresses.Count,
                        Addresses = _mapper.Map<List<AddressQuery>>(x.CustomerAddresses.Select(x => x.Address))
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

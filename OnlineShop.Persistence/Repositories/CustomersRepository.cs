using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Customers.Queries;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.Persistence.Repositories
{
    public class CustomersRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly ShopDbContext _context;

        public CustomersRepository(ShopDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        public async Task<List<GetCustomerQuery>> GetCustomersAsync(int page, int count)
        {
            try
            {
                var max = _context.Customers.Count();
                var maxPages = max / count;
                var startIndex = page * count > max ? max - (max - (maxPages * count)) : page * count;
                var takeCount = (page + 1) * count > max ?  max - maxPages * count : count;

                var toReturn = await _context.Customers
                    .Include(x => x.CustomerAddresses)
                    .OrderBy(x => x.Id)
                    .Skip(startIndex)
                    .Take(takeCount)
                    .Select(customer => new GetCustomerQuery()
                    {
                        CompanyName = customer.CompanyName,
                        EmailAddress = customer.EmailAddress,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Phone = customer.Phone,
                        NumberOfAddresses = customer.CustomerAddresses.Count,
                        Password = "******"
                    })
                    .ToListAsync();

                return toReturn;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }


    }
}

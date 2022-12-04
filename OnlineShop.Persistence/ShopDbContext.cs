using System.Data;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Customers;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.Persistence
{
    public class ShopDbContext : DbContext, IUnitOfWork
    {
        private readonly string _connectionString;

        public ShopDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfigurationsFromAssembly(typeof(ShopDbContext).Assembly);
        }

        public DbSet<Customer> Customers { get; set; }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken)
        {
            var savedCount = await SaveChangesAsync(cancellationToken);

            if (savedCount > 0)
                return true;

            return false;
        }
    }
}

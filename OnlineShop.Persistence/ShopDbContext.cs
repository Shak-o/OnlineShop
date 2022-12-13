using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Accounts;
using OnlineShop.Domain.Addresses;
using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Models;
using OnlineShop.Domain.ProductCategories;
using OnlineShop.Domain.Products;
using OnlineShop.Domain.SalesOrderHeaders;
using OnlineShop.Persistence.Helpers;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.Persistence;

public partial class ShopDbContext : IdentityDbContext<Account>, IUnitOfWork
{
    public ShopDbContext()
    {
    }

    public ShopDbContext(DbContextOptions<ShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }
    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<BuildVersion> BuildVersions { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductDescription> ProductDescriptions { get; set; }

    public virtual DbSet<ProductModel> ProductModels { get; set; }

    public virtual DbSet<ProductModelProductDescription> ProductModelProductDescriptions { get; set; }

    public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }

    public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }

    public virtual DbSet<VGetAllCategory> VGetAllCategories { get; set; }

    public virtual DbSet<VProductAndDescription> VProductAndDescriptions { get; set; }

    public virtual DbSet<VProductModelCatalogDescription> VProductModelCatalogDescriptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddEntityConfigurations();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopDbContext).Assembly);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken)
    {
        var savedCount = await SaveChangesAsync(cancellationToken);

        if (savedCount > 0)
            return true;

        return false;
    }
}

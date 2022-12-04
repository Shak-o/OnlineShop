using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Customers;

namespace OnlineShop.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "SalesLT");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("CustomerId");
            builder.Property(x => x.ModifiedDate).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.RowGuid).HasColumnName("rowGuid");
        }
    }
}

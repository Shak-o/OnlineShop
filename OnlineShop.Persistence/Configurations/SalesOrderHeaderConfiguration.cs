using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.SalesOrderHeaders;

namespace OnlineShop.Persistence.Configurations
{
    public class SalesOrderHeaderConfiguration : IEntityTypeConfiguration<SalesOrderHeader>
    {
        public void Configure(EntityTypeBuilder<SalesOrderHeader> builder)
        {
            builder.HasMany(x => x.SalesOrderDetails).WithOne(x => x.SalesOrder).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

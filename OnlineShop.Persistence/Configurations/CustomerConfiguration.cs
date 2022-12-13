using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Customers;

namespace OnlineShop.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.ModifiedDate)
                .HasDefaultValueSql("getdate()")
                .HasComment("Date and time the record was last updated.")
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("datetime")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
            
            //builder.Property(x => x.PasswordHash).HasMaxLength(300);
        }
    }
}

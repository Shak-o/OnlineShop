using Microsoft.EntityFrameworkCore;
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
                .ValueGeneratedOnAddOrUpdate()
                .HasComment("Date and time the record was last updated.")
                .HasColumnType("datetime");

            builder.Property(x => x.PasswordHash).HasMaxLength(300);
            builder.Property(x => x.PasswordSalt).HasMaxLength(150);
        }
    }
}

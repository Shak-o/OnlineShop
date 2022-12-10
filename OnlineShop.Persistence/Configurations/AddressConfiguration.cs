using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Addresses;

namespace OnlineShop.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(x => x.Id).HasColumnName("AddressID");

            builder.Property(x => x.ModifiedDate)
                .HasDefaultValueSql("getdate()")
                .HasComment("Date and time the record was last updated.")
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("datetime")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
        }
    }
}

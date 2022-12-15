using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.ProductCategories;

namespace OnlineShop.Persistence.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property(x => x.ModifiedDate)
                .HasDefaultValueSql("getdate()")
                .HasComment("Date and time the record was last updated.")
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("datetime")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
        }
    }
}

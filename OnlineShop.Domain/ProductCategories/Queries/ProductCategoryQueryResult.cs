namespace OnlineShop.Domain.ProductCategories.Queries
{
    public class ProductCategoryQueryResult
    {
        public int Id { get; set; }
        /// <summary>
        /// Product category identification number of immediate ancestor category. Foreign key to ProductCategory.ProductCategoryID.
        /// </summary>
        public int? ParentProductCategoryId { get; set; }

        /// <summary>
        /// Category description.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public ProductCategoryQueryResult ParentProductCategory { get; set; }
        public int ProductCount { get; set; }
    }
}

﻿namespace OnlineShop.Domain.ProductCategories.Queries
{
    public class ProductCategoryListQueryResult
    {
        /// <summary>
        /// Category description.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public int ProductCount { get; set; }
    }
}

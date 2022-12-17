using System.ComponentModel.DataAnnotations;
using OnlineShop.Domain.ProductCategories.Queries;

namespace OnlineShop.Domain.Products.Queries
{
    public class ProductQueryResult
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(25)]
        public string ProductNumber { get; set; } = null!;

        [StringLength(15)]
        [DataType(DataType.Currency)]
        public string? Color { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal StandardCost { get; set; }

        [Required]
        public decimal ListPrice { get; set; }

        [StringLength(5)]
        public string? Size { get; set; }

        public decimal? Weight { get; set; }

        public int? ProductCategoryId { get; set; }

        public int? ProductModelId { get; set; }

        [Required]
        public DateTime SellStartDate { get; set; }


        public DateTime? SellEndDate { get; set; }

        /// <summary>
        /// Date the product was discontinued.
        /// </summary>
        public DateTime? DiscontinuedDate { get; set; }
        
        public string ThumbNailPhotoBase64 { get; set; }

        [Required]
        public byte[] ThumbNailPhoto { get; set; }

        public int OrderCount { get; set; }
        public ProductCategoryQueryResult ProductCategory { get; set; }
        public ProductModelQueryResult ProductModel { get; set; }
    }
}

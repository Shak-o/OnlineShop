using MediatR;

namespace OnlineShop.Domain.ProductCategories.Commands
{
    public class UpdateProductCategoryCommand : IRequest
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
    }
}

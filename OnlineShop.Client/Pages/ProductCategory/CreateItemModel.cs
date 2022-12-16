using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Client.Pages.ProductCategory
{
    public class CreateItemModel
    {
        public string? ChosenParentCategory { get; set; }

        [Required]
        public string ProductName { get; set; }
    }
}

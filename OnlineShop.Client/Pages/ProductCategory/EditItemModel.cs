using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Client.Pages.ProductCategory
{
    public class EditItemModel
    {
        public string? ChosenParentCategory { get; set; }

        [Required]
        public string ProductName { get; set; }
        public int ProductCount { get; set; }
    }
}

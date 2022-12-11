using MediatR;

namespace OnlineShop.Domain.ProductCategories.Commands
{
    public class DeleteProductCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}

using MediatR;
using Microsoft.Extensions.Options;
using OnlineShop.App.Options;
using OnlineShop.Domain.ProductCategories.Commands;
using OnlineShop.Domain.ProductCategories.Queries;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.ProductCategories
{
    public class GetProductCategoriesCommandHandler : IRequestHandler<GetProductCategoriesCommand, List<ProductCategoryListQueryResult>>
    {
        private readonly IProductCategoryRepository _repository;
        private readonly IOptions<PagingOptions> _options;

        public GetProductCategoriesCommandHandler(IProductCategoryRepository repository, IOptions<PagingOptions> options)
        {
            _repository = repository;
            _options = options;
        }

        public async Task<List<ProductCategoryListQueryResult>> Handle(GetProductCategoriesCommand request, CancellationToken cancellationToken)
        {
            return await _repository.GetProductCategoriesAsync(_options.Value.Count, request.Page);
        }
    }
}

using AutoMapper;
using MediatR;
using OnlineShop.Domain.ProductCategories;
using OnlineShop.Domain.ProductCategories.Commands;
using OnlineShop.Domain.ProductCategories.Queries;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.ProductCategories
{
    public class GetProductCategoryCommandHandler : IRequestHandler<GetProductCategoryCommand, ProductCategoryQueryResult>
    {
        private readonly IProductCategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetProductCategoryCommandHandler(IProductCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductCategoryQueryResult> Handle(GetProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetFirstAsync(
                x => x.Id == request.Id, 
                cancellationToken,
                "Products",
                "ParentProductCategory");

            var convert = _mapper.Map<ProductCategory, ProductCategoryQueryResult>(result);

            return convert;
        }
    }
}

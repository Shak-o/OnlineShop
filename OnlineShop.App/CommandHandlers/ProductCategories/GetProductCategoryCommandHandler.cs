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
            var result = await _repository.GetFirstNoTrackingAsync(
                x => x.Id == request.Id, 
                cancellationToken);

            if (result.ParentProductCategoryId != 0)
            {
                var parent = await _repository.GetFirstOrDefaultNoTrackingAsync(x => x.Id == result.ParentProductCategoryId,
                    cancellationToken);
                result.ParentProductCategory = parent;
            }
            
            var convert = _mapper.Map<ProductCategory, ProductCategoryQueryResult>(result);

            return convert;
        }
    }
}

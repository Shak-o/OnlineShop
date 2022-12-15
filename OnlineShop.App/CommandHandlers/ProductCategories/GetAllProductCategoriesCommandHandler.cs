using AutoMapper;
using MediatR;
using OnlineShop.Domain.ProductCategories.Commands;
using OnlineShop.Domain.ProductCategories.Queries;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.ProductCategories
{
    public class GetAllProductCategoriesCommandHandler : IRequestHandler<GetAllProductCategoriesCommand, List<ProductCategoryQueryResult>>
    {
        private readonly IProductCategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductCategoriesCommandHandler(IProductCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductCategoryQueryResult>> Handle(GetAllProductCategoriesCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetWithoutTrackingAsync(cancellationToken: cancellationToken);
            var convert = _mapper.Map<List<ProductCategoryQueryResult>>(result);
            
            return convert;
        }
    }
}

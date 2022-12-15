using AutoMapper;
using MediatR;
using OnlineShop.Domain.ProductCategories;
using OnlineShop.Domain.ProductCategories.Commands;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.ProductCategories
{
    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand>
    {
        private readonly IProductCategoryRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductCategoryCommandHandler(IProductCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var convert = _mapper.Map<UpdateProductCategoryCommand, ProductCategory>(request);
            convert.ModifiedDate = DateTime.Now;
            await _repository.UpdateAsync(convert, cancellationToken);

            return Unit.Value;
        }
    }
}

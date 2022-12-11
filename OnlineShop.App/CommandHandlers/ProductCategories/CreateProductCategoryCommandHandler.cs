using AutoMapper;
using MediatR;
using OnlineShop.Domain.ProductCategories;
using OnlineShop.Domain.ProductCategories.Commands;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.ProductCategories
{
    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand>
    {
        private readonly IProductCategoryRepository _repository;
        private readonly IMapper _mapper;
        public CreateProductCategoryCommandHandler(IProductCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var convert = _mapper.Map<CreateProductCategoryCommand, ProductCategory>(request);
                await _repository.AddAsync(convert, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error, cant add product category: {ex.Message}");
            }

            return Unit.Value;
        }
    }
}

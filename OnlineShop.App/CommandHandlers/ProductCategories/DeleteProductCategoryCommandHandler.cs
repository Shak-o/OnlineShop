using AutoMapper;
using MediatR;
using OnlineShop.App.Exceptions;
using OnlineShop.Domain.ProductCategories.Commands;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.ProductCategories
{
    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand>
    {
        private readonly IProductCategoryRepository _repository;
        private readonly IMapper _mapper;

        public DeleteProductCategoryCommandHandler(IProductCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteProductCategoryAsync(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}

using MediatR;
using OnlineShop.App.Exceptions;
using OnlineShop.Domain.Products;
using OnlineShop.Domain.Products.Commands;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Products
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.DeleteAsync(request.Id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new AppException($"cant delete {request.Id}: {ex.Message}");
            }
            return Unit.Value;
        }
    }
}

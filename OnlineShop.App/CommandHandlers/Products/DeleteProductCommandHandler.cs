using MediatR;
using OnlineShop.App.Exceptions;
using OnlineShop.Domain.Models;
using OnlineShop.Domain.Products;
using OnlineShop.Domain.Products.Commands;
using OnlineShop.Domain.SalesOrderHeaders;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Products
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _repository;
        
        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_repository.CheckOnDelete(request.Id)) return false;

                await _repository.DeleteAsync(request.Id, cancellationToken);
                return true;

            }
            catch (Exception ex)
            {
                throw new AppException($"cant delete {request.Id}: {ex.Message}");
            }
        }
    }
}

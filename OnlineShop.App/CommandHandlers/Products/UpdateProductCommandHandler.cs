using System.Text;
using AutoMapper;
using MediatR;
using OnlineShop.Domain.Products;
using OnlineShop.Domain.Products.Commands;
using OnlineShop.Domain.Products.Queries;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Products
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var map = _mapper.Map<ProductQueryResult, Product>(request.Product);
                await _repository.UpdateProductAsync(map, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during update: {ex.Message}");
            }

            return Unit.Value;
        }
    }
}

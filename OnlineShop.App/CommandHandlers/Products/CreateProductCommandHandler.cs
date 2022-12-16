using AutoMapper;
using MediatR;
using OnlineShop.App.Exceptions;
using OnlineShop.Domain.Products;
using OnlineShop.Domain.Products.Commands;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Products
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var convert = _mapper.Map<Product>(request.Product);
                await _repository.AddAsync(convert, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new AppException($"Error during product creation: {ex.Message}");
            }

            return Unit.Value;
        }
    }
}

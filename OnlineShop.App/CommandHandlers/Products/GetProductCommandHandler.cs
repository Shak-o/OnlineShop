using AutoMapper;
using MediatR;
using OnlineShop.App.Exceptions;
using OnlineShop.Domain.Products;
using OnlineShop.Domain.Products.Commands;
using OnlineShop.Domain.Products.Queries;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Products
{
    public class GetProductCommandHandler : IRequestHandler<GetProductCommand, ProductQueryResult>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetProductCommandHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductQueryResult> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.GetFirstAsync(x => x.Id == request.Id, cancellationToken);
                var convert = _mapper.Map<Product, ProductQueryResult>(result);
                return convert;
            }
            catch (Exception ex)
            {
                throw new AppException($"Error during get {ex.Message}");
            }
        }
    }
}

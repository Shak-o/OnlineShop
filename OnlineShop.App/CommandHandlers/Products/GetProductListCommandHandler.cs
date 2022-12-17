using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using OnlineShop.App.Options;
using OnlineShop.Domain.Products;
using OnlineShop.Domain.Products.Commands;
using OnlineShop.Domain.Products.Queries;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Products
{
    public class GetProductListCommandHandler : IRequestHandler<GetProductListCommand, List<ProductQueryResult>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly IOptions<PagingOptions> _options;

        public GetProductListCommandHandler(IProductRepository repository, IMapper mapper, IOptions<PagingOptions> options)
        {
            _repository = repository;
            _mapper = mapper;
            _options = options;
        }

        public async Task<List<ProductQueryResult>> Handle(GetProductListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.GetAllProductsAsync(request.Page, _options.Value.Count);
                var convert = _mapper.Map<List<ProductQueryResult>>(result);

                return convert;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during products get: {ex.Message}");
            }
            
        }
    }
}

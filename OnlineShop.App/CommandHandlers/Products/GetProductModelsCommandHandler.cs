using AutoMapper;
using MediatR;
using OnlineShop.Domain.Models;
using OnlineShop.Domain.Products.Commands;
using OnlineShop.Domain.Products.Queries;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Products
{
    public class GetProductModelsCommandHandler : IRequestHandler<GetProductModelsCommand, List<ProductModelQueryResult>>
    {
        private readonly IRepository<ProductModel> _repository;
        private IMapper _mapper;

        public GetProductModelsCommandHandler(IRepository<ProductModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductModelQueryResult>> Handle(GetProductModelsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.GetWithoutTrackingAsync(cancellationToken: cancellationToken);
                var convert = _mapper.Map<List<ProductModelQueryResult>>(result);
                return convert;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}

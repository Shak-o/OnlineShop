using AutoMapper;
using MediatR;
using OnlineShop.App.Exceptions;
using OnlineShop.Domain.SalesOrderHeaders;
using OnlineShop.Domain.SalesOrderHeaders.Commands;
using OnlineShop.Domain.SalesOrderHeaders.Queries;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Orders
{
    public class GetOrderCommandHandler : IRequestHandler<GetOrderCommand, OrderQueryResult>
    {
        private readonly IOrdersRepository _repository;
        private readonly IMapper _mapper;

        public GetOrderCommandHandler(IOrdersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OrderQueryResult> Handle(GetOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.GetOrderAsync(request.Id);

                return result;
            }
            catch (Exception ex)
            {
                throw new AppException($"im tired {ex.Message}");
            }
        }
    }
}

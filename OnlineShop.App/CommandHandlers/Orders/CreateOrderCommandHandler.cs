using AutoMapper;
using MediatR;
using OnlineShop.App.Exceptions;
using OnlineShop.Domain.SalesOrderHeaders;
using OnlineShop.Domain.SalesOrderHeaders.Commands;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Orders
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IRepository<SalesOrderHeader> _repository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IRepository<SalesOrderHeader> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var convert = _mapper.Map<SalesOrderHeader>(request.Order);
                await _repository.AddAsync(convert, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new AppException($"Error during saving:{ex.Message}");
            }

            return Unit.Value;
        }
    }
}

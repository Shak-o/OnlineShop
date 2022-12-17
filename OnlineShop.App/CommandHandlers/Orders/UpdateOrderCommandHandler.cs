using AutoMapper;
using MediatR;
using OnlineShop.Domain.SalesOrderHeaders;
using OnlineShop.Domain.SalesOrderHeaders.Commands;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Orders
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IRepository<SalesOrderHeader> _repository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IRepository<SalesOrderHeader> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var convert = _mapper.Map<SalesOrderHeader>(request.Order);
                await _repository.UpdateAsync(convert, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"err {ex.Message}");
            }
            return Unit.Value;
        }
    }
}

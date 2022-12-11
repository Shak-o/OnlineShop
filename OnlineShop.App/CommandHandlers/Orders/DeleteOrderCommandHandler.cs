using MediatR;
using OnlineShop.Domain.SalesOrderHeaders;
using OnlineShop.Domain.SalesOrderHeaders.Commands;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Orders
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IRepository<SalesOrderHeader> _repository;

        public DeleteOrderCommandHandler(IRepository<SalesOrderHeader> repository)
        {
            _repository = repository;
        }
        
        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.DeleteAsync(request.Id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Cant del:{ex.Message}");
            }
            return Unit.Value;
        }
    }
}

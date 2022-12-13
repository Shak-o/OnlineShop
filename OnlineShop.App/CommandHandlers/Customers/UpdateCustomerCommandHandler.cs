using AutoMapper;
using MediatR;
using OnlineShop.App.Helpers;
using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Customers.Commands;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Customers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IRepository<Customer> _repository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IRepository<Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            request.ModifiedDate = DateTime.Now;
            
            var converted = _mapper.Map<Customer>(request);
            var hashAndSalt = HashHelper.CreateHashWithSalt(request.Password);
            
            //converted.PasswordHash = hashAndSalt.Item1;

            await _repository.UpdateAsync(converted, cancellationToken);

            return Unit.Value;
        }
    }
}

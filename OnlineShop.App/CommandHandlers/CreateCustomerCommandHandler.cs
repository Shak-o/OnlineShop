using AutoMapper;
using MediatR;
using OnlineShop.App.Helpers;
using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Customers.Commands;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
    {
        private readonly IRepository<Customer> _repository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IRepository<Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var mapped = _mapper.Map<Customer>(request);

            var saltAndPass = HashHelper.CreateHashWithSalt();
            
            mapped.PasswordHash = saltAndPass.Item1;
            mapped.PasswordSalt = saltAndPass.Item2;

            await _repository.AddAsync(mapped, cancellationToken);

            return Unit.Value;
        }
    }
}

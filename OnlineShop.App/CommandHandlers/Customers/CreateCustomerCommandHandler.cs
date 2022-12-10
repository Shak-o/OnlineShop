using AutoMapper;
using MediatR;
using OnlineShop.App.Helpers;
using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Customers.Commands;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Customers
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
            try
            {
                var mapped = _mapper.Map<Customer>(request);

                var saltAndPass = HashHelper.CreateHashWithSalt(request.Password);

                mapped.PasswordHash = saltAndPass.Item1!;
                mapped.PasswordSalt = saltAndPass.Item2;
                mapped.Rowguid = Guid.NewGuid();

                await _repository.AddAsync(mapped, cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during creation of customer:\n{ex.Message}");
            }
        }
    }
}

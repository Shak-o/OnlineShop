using AutoMapper;
using OnlineShop.Domain.Addresses;
using OnlineShop.Domain.Addresses.Queries;
using OnlineShop.Domain.Customers;
using OnlineShop.Domain.Customers.Commands;

namespace OnlineShop.App.Mapping
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<CreateCustomerCommand, Customer>();
            CreateMap<UpdateCustomerCommand, Customer>();
            CreateMap<Address, AddressQuery>();
        }
    }
}

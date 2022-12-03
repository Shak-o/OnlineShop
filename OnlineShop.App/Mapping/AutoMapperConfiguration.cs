using AutoMapper;
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
        }
    }
}

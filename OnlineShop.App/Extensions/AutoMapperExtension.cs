using Microsoft.Extensions.DependencyInjection;
using OnlineShop.App.Mapping;

namespace OnlineShop.App.Extensions
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddTheMapper(this IServiceCollection service)
        {
            
            return service;
        }

    }
}

using Microsoft.Extensions.DependencyInjection;

namespace OnlineShop.App.Extensions
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection service)
        {
            service.AddAutoMapper();
            return service;
        }
    }
}

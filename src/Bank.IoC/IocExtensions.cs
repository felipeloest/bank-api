using Bank.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.IoC
{
    public static class IocExtensions
    {
        public static void AddApplicationIoCServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationServices(configuration);
        }
    }
}
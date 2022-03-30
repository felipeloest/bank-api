using Bank.Application.CommandStack;
using Bank.Application.CommandStack.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.Application
{
    public static class ServicesExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IResetAppService, ResetAppService>();
            services.AddScoped<IAccountAppService, AccountAppService>();
        }
    }
}

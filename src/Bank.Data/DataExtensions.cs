using Bank.Data.Domain;
using Bank.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data
{
    public static class DataExtensions
    {
        public static void AddInfraDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Configure the connection string to a given DbContext
            services.AddDbContext<Context>(opt =>
            {
                opt.UseInMemoryDatabase("Context");
            });

            services.AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}

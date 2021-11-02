using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Interfaces.Repositores;
using ZarvanOrder.Repositores;

namespace ZarvanOrder.Extensions.DependencyRegistration
{
    internal static class Repositores
    {
        internal static IServiceCollection AddRepositores(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            return services;
        }
    }
}

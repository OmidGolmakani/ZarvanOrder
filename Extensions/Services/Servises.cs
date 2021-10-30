using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Data.DbContext;
using ZarvanOrder.Interfaces.Repositores;

namespace ZarvanOrder.Extensions.Services
{
    internal static class Servises
    {
        internal static IServiceCollection AddServises(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer()
               .AddDbContext<AppDbContext>(options =>
               {
                   options.UseSqlServer(configuration["Data:ConnectionString"],
                       options => options.MigrationsAssembly(typeof(Startup).Assembly.FullName));
               });
            services.AddScoped<Func<AppDbContext>>((provider) => () => provider.GetService<AppDbContext>());
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
    }
}

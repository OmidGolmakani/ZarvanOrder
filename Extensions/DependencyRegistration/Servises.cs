using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Data.DbContext;
using ZarvanOrder.Interfaces.DataServices;
using ZarvanOrder.Interfaces.Repositores;
using ZarvanOrder.Model.Validation;
using ZarvanOrder.Repositores;
using ZarvanOrder.Services.Data;

namespace ZarvanOrder.Extensions.DependencyRegistration
{
    internal static class Servises
    {
        internal static IServiceCollection AddServises(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer()
               .AddDbContext<AppDbContext>(options =>
               {
                   options.UseSqlServer(configuration["Data:DefaultConnectionString"],
                       options => options.MigrationsAssembly(typeof(Startup).Assembly.FullName));
                   options.UseSqlServer(configuration["Data:SecondConnectionString"],
                       options => options.MigrationsAssembly(typeof(Startup).Assembly.FullName));
               });
            services.AddScoped<Func<AppDbContext>>((provider) => () => provider.GetService<AppDbContext>());
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}

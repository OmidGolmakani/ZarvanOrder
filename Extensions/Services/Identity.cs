using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Data.DbContext;

namespace ZarvanOrder.Extensions.Services
{
    internal static class Identity
    {
        internal static IServiceCollection MyIdentity(this IServiceCollection services)
        {
            services.AddIdentity<Model.Entites.User, Model.Entites.Role>(config =>
            {
                config.Password.RequireDigit = false;
                //config.Password.RequiredLength = 10;
                config.Password.RequireLowercase = false;
                config.Password.RequireUppercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.User.RequireUniqueEmail = false;
                config.SignIn.RequireConfirmedEmail = false;
                config.SignIn.RequireConfirmedPhoneNumber = true;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddUserStore<UserStores>()
            .AddRoles<Model.Entites.Role>()
            .AddDefaultTokenProviders();
            return services;
        }
    }
}

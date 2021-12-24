using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Configs.AutoMapper;

namespace ZarvanOrder.Extensions.DependencyRegistration
{
    internal static class _AutoMapper
    {
        internal static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            var Config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfile());
                cfg.AddProfile(new CustomerProfile());
                cfg.AddProfile(new RegionProfile());
                cfg.AddProfile(new MarketerAccessRegionProfile());
            });
            var mapper = Config.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}

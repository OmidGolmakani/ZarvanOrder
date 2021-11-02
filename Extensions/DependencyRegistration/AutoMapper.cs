using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Extensions.DependencyRegistration
{
    internal static class AutoMapper
    {
        internal static IServiceCollection AddAutoMapper(this IServiceCollection Services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Configs.AutoMapper());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            Services.AddSingleton(mapper);
            return Services;
        }
    }
}

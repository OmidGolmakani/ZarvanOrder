using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Extensions.Services
{
    internal static class Swagger
    {
        internal static IServiceCollection AddSwagger(this IServiceCollection service)
        {
            return service;
        }
    }
}

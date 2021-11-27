using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ZarvanOrder.Configs.Swagger
{
    public class SwaggerHeaderParameters : IOperationFilter
    {
        private readonly IWebHostEnvironment _env;

        public SwaggerHeaderParameters(IWebHostEnvironment env)
        {
            this._env = env;
        }
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            if (_env.IsDevelopment() == false && IsMethodWithHttpGetAttribute(context))
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "Access-Control-Allow-Origin",
                    In = ParameterLocation.Header,
                    Description = "",
                    Required = true
                });
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "Access-Control-Allow-Credentials",
                    In = ParameterLocation.Header,
                    Description = "Please Send 'True'",
                    Required = true
                });
            }
        }
        private bool IsMethodWithHttpGetAttribute(OperationFilterContext context)
        {
            return context.MethodInfo.CustomAttributes.Any(attribute =>
            attribute.AttributeType == typeof(HttpDeleteAttribute) ||
            attribute.AttributeType == typeof(HttpPutAttribute) ||
            attribute.AttributeType == typeof(HttpPatchAttribute));
        }
    }
}

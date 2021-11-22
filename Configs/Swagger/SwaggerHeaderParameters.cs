using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace ZarvanOrder.Configs.Swagger
{
    public class SwaggerHeaderParameters : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "MyHeaderField",
                In =ParameterLocation.Header,
                Description = "My header field",
                Required = true
            });
        }
    }
}

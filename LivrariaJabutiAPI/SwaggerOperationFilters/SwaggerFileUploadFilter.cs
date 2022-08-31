using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Reflection;

namespace LivrariaJabutiAPI.Web.SwaggerOperationFilters
{
    public class SwaggerFileUploadFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var fileUploadMime = "multipart/form-data";
            if (operation.RequestBody == null || !operation.RequestBody.Content.Any(x => x.Key.Equals(fileUploadMime, StringComparison.InvariantCultureIgnoreCase)))
                return;

            var formParams = context.MethodInfo.GetParameters().ToList().Where(p => p.ParameterType == typeof(IFormFile));

            if (formParams == null)
                return;

            operation.RequestBody.Content[fileUploadMime].Schema.Properties =
                    formParams.ToDictionary(k => k.Name, v => new OpenApiSchema()
                    {
                        Type = "string",
                        Format = "binary"
                    });
        }
            
        
    }
}

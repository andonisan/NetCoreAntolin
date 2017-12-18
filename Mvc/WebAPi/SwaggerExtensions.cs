using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPi
{
    using System.Linq;
    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerGen;

    namespace WEBAPI.Swagger
    {
        public class RemoveVersionParameters : IOperationFilter
        {
            public void Apply(Operation operation, OperationFilterContext context)
            {
                // Remove version parameter from all Operations
                var versionParameter = operation.Parameters.Single(p => p.Name == "version");
                operation.Parameters.Remove(versionParameter);
            }
        }

        public class SetVersionInPaths : IDocumentFilter
        {
            public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
            {
                swaggerDoc.Paths = swaggerDoc.Paths
                    .ToDictionary(
                        path => path.Key.Replace("v{version}", swaggerDoc.Info.Version),
                        path => path.Value
                    );
            }
        }
    }
}

using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BSF.Extensions
{
    /// <summary>
    /// Фильтр, активирующий значения по-умолчанию для Swagger UI.
    /// </summary>
    public class SchemaFilter : ISchemaFilter
    {
        /// <summary/>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema.Properties == null)
            {
                return;
            }

            foreach (var property in schema.Properties)
            {
                if (property.Value.Default != null && property.Value.Example == null)
                {
                    property.Value.Example = property.Value.Default;
                }
            }
        }

    }
}
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace BSF.Extensions
{
    /// <summary>
    /// Расширение стартапа для настройки Swagger.
    /// </summary>
    internal static class SwaggerExtension
    {
        private const string Version = "v1";
        private const string Title = "BoringStocktakingFan API";

        internal static IServiceCollection AddSwagger(
            this IServiceCollection services)
        {
            return services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc(Version, new OpenApiInfo { Title = Title, Version = Version, Contact = new OpenApiContact { Name = "Артемий Хамнуев", Email = "artemiykhamnuyev@gmail.com"} });
                    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
                    c.SchemaFilter<SchemaFilter>();
                });
        }

        internal static IApplicationBuilder UseSwaggerWithCustomSettings(
            this IApplicationBuilder builder)
        {
            return builder
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{Title} {Version}");
                });
        }
    }
}
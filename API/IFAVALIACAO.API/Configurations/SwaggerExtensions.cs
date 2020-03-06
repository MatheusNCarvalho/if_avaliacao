using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace IFAVALIACAO.API.Configurations
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "BullApp",
                        Version = "v1",
                        Description = "API REST - BullApp",
                    });
                AddSecurity(c);
            });


            return services;
        }

        private static void AddSecurity(SwaggerGenOptions options)
        {
            var security = new Dictionary<string, IEnumerable<string>>
            {
                {"Bearer", new string[] { }},
            };

            options.AddSecurityDefinition("Bearer", new ApiKeyScheme
            {
                In = "header",
                Description = "Autenticação baseada em Json Web Token (JWT)",
                Name = "Authorization",
                Type = "apiKey",

            });

            options.AddSecurityRequirement(security);
        }
    }
}

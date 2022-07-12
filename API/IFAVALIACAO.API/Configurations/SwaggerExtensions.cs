using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
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
                    new OpenApiInfo
                    {
                        Title = "BullApp",
                        Version = "v1",
                        Description = "API REST - BullApp",
                    });
                c.CustomSchemaIds(c => c.FullName);
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

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Autenticação baseada em Json Web Token (JWT)",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,

            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement(){
                {   new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                      Scheme = "oauth2",
                      Name = "Bearer",
                      In = ParameterLocation.Header,
                    },  new List<string>()
                }
            });
        }
    }
}

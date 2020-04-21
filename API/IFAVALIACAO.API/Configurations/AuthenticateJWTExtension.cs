using System;
using IFAVALIACAO.API.Domain.Interfaces.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IFAVALIACAO.API.Configurations
{
    public static class AuthenticateJWTExtension
    {
        public static IServiceCollection AddAutheticateJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var sp = services.BuildServiceProvider();

            var signingConfigurations = sp.GetService<ISigningConfiguration>();
            signingConfigurations.GenerateKey();

            var tokenConfigurations = sp.GetService<ITokenConfiguration>();

            new ConfigureFromConfigurationOptions<ITokenConfiguration>(configuration.GetSection("TokenConfigurations"))
                .Configure(tokenConfigurations);
            

            services.AddSingleton(signingConfigurations);
            services.AddSingleton(tokenConfigurations);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearedOptions =>
            {
                bearedOptions.SaveToken = true;

                var paramsValidation = bearedOptions.TokenValidationParameters;

                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidateAudience = true;
                paramsValidation.ValidateIssuer = true;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;

                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;

                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            return services;
        }
    }
}
using IFAVALIACAO.API.Data;
using IFAVALIACAO.API.Data.Authentication;
using IFAVALIACAO.API.Data.Repository;
using IFAVALIACAO.API.Domain.Authentication;
using IFAVALIACAO.API.Domain.Repository;
using IFAVALIACAO.API.Services;
using IFAVALIACAO.API.Services.Interfaces;
using IFAVALIACAO.API.Services.Notifications;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace IFAVALIACAO.API.Configurations.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ITokenEncoder, TokenEncoder>();
            services.AddScoped<IAutenticacaoService, AutenticacaoService>();
            services.AddScoped<IFazendaService, FazendaService>();

            services.AddSingleton<ISigningConfiguration, SigningConfiguration>();
            services.AddSingleton<ITokenConfiguration, TokenConfiguration>();

            services.AddScoped<IFDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
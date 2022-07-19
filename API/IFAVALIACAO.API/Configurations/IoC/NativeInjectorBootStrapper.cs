using IFAVALIACAO.API.Data;
using IFAVALIACAO.API.Data.Authentication;
using IFAVALIACAO.API.Data.Repository;
using IFAVALIACAO.API.Domain.Interfaces.Authentication;
using IFAVALIACAO.API.Domain.Interfaces.Repository;
using IFAVALIACAO.API.Domain.Interfaces.Services;
using IFAVALIACAO.API.Domain.Notifications;
using IFAVALIACAO.API.Domain.Services;
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
            services.AddScoped<IVacaService, VacaService>();

            services.AddSingleton<ISigningConfiguration, SigningConfiguration>();
            services.AddSingleton<ITokenConfiguration, TokenConfiguration>();
            services.AddScoped<IUserSession, UserSession>();

            services.AddScoped<IFDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IFazendaRepository, FazendaRepository>();
            services.AddScoped<IVacaRepository, VacaRepository>();
            services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
            services.AddScoped<IAvaliacaoService, AvaliacaoService>();
            

            return services;
        }
    }
}
using IFAVALIACAO.API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IFAVALIACAO.API.Configurations
{
    public static class InitializeDatabaseExtesion
    {
        public static IApplicationBuilder UseInitializeDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<IFDbContext>().Database.Migrate();
            }

            return app;
        }
    }
}
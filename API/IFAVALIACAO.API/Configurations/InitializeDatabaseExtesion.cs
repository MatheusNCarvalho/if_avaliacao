using System;
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
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            
            try
            {
                scope.ServiceProvider.GetRequiredService<IFDbContext>().Database.Migrate();
            }
            catch (Exception ex)
            {
                //Log errors or do anything you think it's needed
                Console.Write(ex.InnerException?.Message ?? ex.Message);
                throw;
            }

            return app;
        }
    }
}
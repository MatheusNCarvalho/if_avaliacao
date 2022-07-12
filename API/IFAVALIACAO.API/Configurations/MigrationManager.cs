using System;
using IFAVALIACAO.API.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IFAVALIACAO.API.Configurations
{
    public static class MigrationManager
    {
        public static IWebHost MigrateDatabase(this IWebHost host)
     {
         using (var scope = host.Services.CreateScope())
         {
             using (var appContext = scope.ServiceProvider.GetRequiredService<IFDbContext>())
             {
                 try
                 {
                     appContext.Database.Migrate();
                 }
                 catch (Exception ex)
                 {
                     //Log errors or do anything you think it's needed
                     Console.Write(ex.InnerException?.Message ?? ex.Message);
                     throw;
                 }
             }
         }
         return host;
    }
    }
}
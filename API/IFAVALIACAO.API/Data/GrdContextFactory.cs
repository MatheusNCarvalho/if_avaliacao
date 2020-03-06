using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace IFAVALIACAO.API.Data
{
    //public class GrdContextFactory : IDesignTimeDbContextFactory<IFDbContext>
    //{

    //    public IFDbContext CreateDbContext(string[] args)
    //    {
    //        //Get environment
    //        string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    //        // Build config
    //        IConfiguration config = new ConfigurationBuilder()
    //            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "."))
    //            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    //            .AddJsonFile($"appsettings.{environment}.json", optional: true)
    //            .AddEnvironmentVariables()
    //            .Build();

    //        // Get connection string
    //        var optionsBuilder = new DbContextOptionsBuilder<IFDbContext>();
    //        var connectionString = config.GetConnectionString("Default");
    //        optionsBuilder.UseSqlServer(connectionString);
    //        return new IFDbContext(optionsBuilder.Options);
    //    }
    //}
}

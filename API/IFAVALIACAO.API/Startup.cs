using AutoMapper;
using IFAVALIACAO.API.Configurations;
using IFAVALIACAO.API.Configurations.IoC;
using IFAVALIACAO.API.Data;
using IFAVALIACAO.API.Middleware;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace IFAVALIACAO.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<IFDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("Default"))
                                                             .EnableSensitiveDataLogging());

            services.AddCors(options =>
            {
                options.AddPolicy("policy", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });

            services.AddMediatR(typeof(Startup));
            services.AddDependencyInjection();            
            services.AddAutoMapper(typeof(Startup));

            services.AddAutheticateJWT(Configuration);
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(GlobalExceptionHandlingFilter));
                options.Filters.Add(new AuthorizeFilter("Bearer"));

            })
              .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)
              .AddNewtonsoftJson(x => { x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore; });
  

            services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("policy");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BullApp");
            });
            app.UseInitializeDatabase();
        }
    }
}

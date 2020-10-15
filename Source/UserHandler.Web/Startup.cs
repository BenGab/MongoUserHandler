using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Reflection;
using UserHandler.Db.Settings;

namespace UserHandler.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<UserDbSettings>(Configuration.GetSection("UsersDatabaseSettings"));
            services.AddSingleton<IDbSettings>(sp => sp.GetRequiredService<IOptions<UserDbSettings>>().Value);

            UserHandler.Db.Configuration.ServiceConfiguration.ConfigureServices(services);
            UserHandler.Repository.Configuration.ServieConfiguarion.ConfigureServices(services);

            services.AddControllers().AddNewtonsoftJson();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "User handle API",
                    Description = "Endpoints documentation for Userhandler API",
                    Version = "v1"
                });

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "apidoc.xml"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "UserHandler API");
            });
        }
    }
}

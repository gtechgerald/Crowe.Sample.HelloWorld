using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sample.HelloWorld.ServiceConfigurations; 
using Sample.HelloWorld.Middleware; 

namespace Sample.HelloWorld
{
    public class Startup
    {
        private const string _apiVersion = "1.0.0"; 

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            ///Configure using custom extensions
            services.ConfigureSettings();
            services.ConfigureTransientServices(); 
            services.ConfigureSwagger(_apiVersion); 
            services.ConfigureCors();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Latest);            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Use the Error Handling Middle ware for exceptions 
            app.UseMiddleware<ErrorHandlingMiddleware>(); 

            //Swagger implementation
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.DocumentTitle = "Crowe Hello World";
                options.RoutePrefix = string.Empty;

                options.SwaggerEndpoint(
                    $"/swagger/{_apiVersion}/swagger.json",
                    $"Crowe Hello World {_apiVersion}");
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

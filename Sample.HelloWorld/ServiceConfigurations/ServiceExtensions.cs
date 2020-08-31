using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sample.HelloWorld.Business.Interfaces;
using Sample.HelloWorld.Business.Services;
using Sample.HelloWorld.Business.Helpers; 
using Sample.HelloWorld.Business.Settings;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;

namespace Sample.HelloWorld.ServiceConfigurations
{
    public static class ServiceExtensions
    {
        private static readonly IConfigurationRoot Configuration; 

        static ServiceExtensions()
        {
            Configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build(); 
        }

        public static void ConfigureSettings(this IServiceCollection services)
        {
            services.Configure<DataStoreSettings>(Configuration.GetSection("DataStoreSettings"));
            services.AddTransient(sp => sp.GetRequiredService<IOptions<DataStoreSettings>>().Value);

            services.Configure<MessageSettings>(Configuration.GetSection("MessageSettings"));
            services.AddTransient(sp => sp.GetRequiredService<IOptions<MessageSettings>>().Value); 
        }

        public static void ConfigureTransientServices(this IServiceCollection services)
        {
            services.AddTransient<IDataStoreFactory, DataStoreFactory>();
            services.AddTransient<IHelloWorldService, HelloWorldService>(); 
        }

        public static void ConfigureCors(this IServiceCollection services)
        {

        }

        public static void ConfigureSwagger(this IServiceCollection services, string apiVersion)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc($"{apiVersion}", new OpenApiInfo
                {
                    Title = "Crowe Hello World API",
                    Version = $"{apiVersion}",
                    Description = "API logic for the application."
                });                

                // FUTURE ENHANCEMENTT:  Ensure that the swagger is secured 
                //var securityScheme = new OpenApiSecurityScheme()
                //{
                //    Description = "Please enter the JWT value",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.Http,
                //    BearerFormat = "JWT",
                //    Scheme = "bearer"
                //};
                //options.AddSecurityDefinition("Bearer", securityScheme);

                //options.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                //        },
                //        new string[] { }
                //    }
                //});
            });
        }
    }
}

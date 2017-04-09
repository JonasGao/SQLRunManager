using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SQLRunManager.Context;
using SQLRunManager.Exceptions;

namespace SQLRunManager
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc(option => option.Filters.Add(typeof(InvalidJsonTypeExceptionHandler)))
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

            // 扫描并注册 Service
            foreach (var serviceType in GetPublicDataServices())
                services.AddTransient(serviceType.AsType());
        }

        private static IEnumerable<TypeInfo> GetPublicDataServices()
        {
            return Assembly.GetEntryAssembly()
                .DefinedTypes.Where(typeInfo => typeInfo.Namespace == "SQLRunManager.Services" &&
                                                !typeInfo.IsAbstract && typeInfo.IsPublic);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();


            DataBase.Configure();
        }
    }
}
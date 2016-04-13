using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using nwfw.Models;
using nwfw.Models.DataSeed;

namespace nwfw
{
    public class Startup
    {
        public static IConfigurationRoot Configuration { get; set; }
        
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver = 
                    new CamelCasePropertyNamesContractResolver();
            });
            
            services.AddTransient<NwfwTestDataSeed>();
            
            services.AddEntityFramework()
                .AddSqlite()
                .AddSqlServer()
                .AddDbContext<NwfwContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
          IApplicationBuilder app, 
          IHostingEnvironment env, 
          ILoggerFactory loggerFactory, 
          NwfwTestDataSeed seed)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIISPlatformHandler();

            app.UseStaticFiles();

            app.UseMvc();
            
            seed.SeedFoSho();
        }

        // Entry point for the application.
        public static void Main(string[] args) => Microsoft.AspNet.Hosting.WebApplication.Run<Startup>(args);
    }
}

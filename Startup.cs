using System;
using AutoMapper;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using nwfw.Mappings;
using nwfw.Models;
using nwfw.Models.DataSeed;
using nwfw.Repositories;
using nwfw.Repositories.Interfaces;

namespace nwfw
{
  public class Startup
  {
    public static IConfigurationRoot Configuration { get; set; }
    private MapperConfiguration _mapperConfiguration { get; set; }
    
    public Startup(IHostingEnvironment env)
    {
      // Set up configuration sources.
      var builder = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddJsonFile("config.json")
        .AddEnvironmentVariables();
      Configuration = builder.Build();
      _mapperConfiguration = new MapperConfiguration(cfg =>
      {
          cfg.AddProfile(new AutoMapperProfileConfiguration());
      });
    }


    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // Add framework services.
      services.AddMvc().AddJsonOptions(options => {
        options.SerializerSettings.ContractResolver = 
          new CamelCasePropertyNamesContractResolver();
      });
      
      // services.AddLogging();
      
      services.AddTransient<NwfwTestDataSeed>();
      
      services.AddEntityFramework()
        .AddSqlite()
        .AddSqlServer()
        .AddDbContext<NwfwContext>();
        
      services.AddScoped<ICustomerRepo, CustomerRepo>();
      services.AddScoped<IOrderRepo, OrderRepo>();
      
      services.AddSingleton<IMapper>(sp => _mapperConfiguration.CreateMapper());
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(
      IApplicationBuilder app, 
      IHostingEnvironment env, 
      ILoggerFactory loggerFactory, 
      NwfwTestDataSeed seed)
    {
      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      loggerFactory.AddDebug(LogLevel.Warning);
      
      app.UseIISPlatformHandler();

      app.UseStaticFiles();

      app.UseMvc();
      
      seed.SeedFoSho();
    }

    // Entry point for the application.
    public static void Main(string[] args) => Microsoft.AspNet.Hosting.WebApplication.Run<Startup>(args);
  }
}

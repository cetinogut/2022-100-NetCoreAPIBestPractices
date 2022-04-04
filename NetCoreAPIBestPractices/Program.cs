using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPIBestPractices
{
    public class Program
    {
        private static IConfiguration Configuration // my addition for best practice
        {
            get
            {
                String env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"; // if no env exists make it produciton

                return new ConfigurationBuilder()
                    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false) //read this, this not optional, you have to read this file
                    //.AddJsonFile("appsettings.development.json", optional: true) // read this one optionally, if exists first read this one.
                    .AddJsonFile("appsettings.{env}.json", optional: true)
                    .AddEnvironmentVariables()
                    .Build();
            }
        }
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseConfiguration(Configuration); //added as a best practice
                    webBuilder.UseStartup<Startup>();
                });
    }
}

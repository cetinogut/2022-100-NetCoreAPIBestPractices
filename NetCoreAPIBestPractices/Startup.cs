using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NetCoreAPIBestPractices.Extensions;
using NetCoreAPIBestPractices.Models;
using NetCoreAPIBestPractices.Service;
using NetCoreAPIBestPractices.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPIBestPractices
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

            services.AddControllers()
                .AddFluentValidation(i => i.DisableDataAnnotationsValidation = true);// use FlentValidation first
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NetCoreAPIBestPractices", Version = "v1" });
            });

            services.AddHealthChecks(); // from my own extensions
            services.ConfigureDasMapping(); // from my own extensions

            services.AddScoped<IContactService, ContactService>(); //when ever I call this service(interface) give me a class instance of ContactService
            services.AddTransient<IValidator<ContactDVO>, ContactValidator>(); // added for fluent validation

            services.AddHttpClient("garantiapi", config =>
            {
                config.BaseAddress = new Uri("https://www.garanti.com");
                config.DefaultRequestHeaders.Add("Authorization", "Bearer 1234567");
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetCoreAPIBestPractices v1"));
            }


            app.UseCustomHealthCheck();
            app.UseResponseCaching();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPIBestPractices.Extensions
{
    public static class HealthCheckConfigExtension
    {
        public static IApplicationBuilder UseCustomHealthCheck(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/api/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
            {

                ResponseWriter = async (context, report) =>
                {
                    await context.Response.WriteAsync("Health is OK"); // the incoming health check request is take nand Ok is written to the response. There is no Controller as Health. This is a fake route. Yuo dont want to get a heath request coming each second to the middlewares
                }
            });

            return app;
        }
    }
}

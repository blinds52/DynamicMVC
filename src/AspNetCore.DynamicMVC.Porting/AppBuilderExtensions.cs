using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.DynamicMVC.Porting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Builder
{
    public static class AppBuilderExtensions
    {

        public static IServiceCollection AddModules(this IServiceCollection serviceCollection, Action<CoreModulesBuilder> options)
        {
            var builder = new CoreModulesBuilder(serviceCollection);
            options(builder);
            return serviceCollection;
        }

        public static IApplicationBuilder UseModules(this IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var modules = app.ApplicationServices.GetServices<ICoreModule>();
            foreach (var coreModule in modules)
            {
                coreModule.Configure(app, loggerFactory);
            }

            return app.Use(async (ctx, next) =>
            {

                Task.WaitAll(
                    ctx.RequestServices.GetServices<ICoreModuleRequestHandler>().Select(h => h.Invoke(ctx)).ToArray());

                await next();
            });
        }
    }
}

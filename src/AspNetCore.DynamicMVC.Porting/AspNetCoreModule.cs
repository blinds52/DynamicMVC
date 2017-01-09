using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspNetCore.DynamicMVC.Porting
{
    public abstract class AspNetCoreModule : ICoreModule, ICoreModuleRequestHandler
    {
        protected ILogger Logger { get; private set; }

        protected AspNetCoreModule()
        {
        }

        protected virtual void Configure(IApplicationBuilder app)
        {
        }

        protected virtual Task Invoke(HttpContext context)
        {
            return Task.FromResult(0);
        }

        IApplicationBuilder ICoreModule.Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            Logger = loggerFactory.CreateLogger(this.GetType());
            Configure(app);
            return app;
        }

        async Task ICoreModuleRequestHandler.Invoke(HttpContext context)
        {
            await Invoke(context);
        }
    }
}

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
    public interface ICoreModule
    {
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        IApplicationBuilder Configure(IApplicationBuilder app, ILoggerFactory loggerFactory);
    }

    public interface ICoreModuleRequestHandler
    {
        Task Invoke(HttpContext context);
    }

}

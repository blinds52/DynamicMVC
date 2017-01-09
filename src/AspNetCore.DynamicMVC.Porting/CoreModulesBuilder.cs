using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AspNetCore.DynamicMVC.Porting;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Builder
{
    public class CoreModulesBuilder
    {
        private readonly IServiceCollection _serviceCollection;

        public CoreModulesBuilder(IServiceCollection serviceCollection)
        {
            if (serviceCollection == null) throw new ArgumentNullException(nameof(serviceCollection));
            _serviceCollection = serviceCollection;
        }

        public CoreModulesBuilder AddModule<TModule>() where TModule : class, ICoreModule
        {
            var initMethod = typeof (TModule).GetMethod("RegisterTypes", new []{typeof(ServiceCollection)});
            initMethod?.Invoke(null, new object[] {_serviceCollection});
            _serviceCollection
                    .AddSingleton<TModule>()
                    .AddScoped<ICoreModule>(sp =>
                        sp.GetService<TModule>());
            if (typeof (ICoreModuleRequestHandler).IsAssignableFrom(typeof (TModule)))
            {
                _serviceCollection.AddScoped(sp =>
                    (ICoreModuleRequestHandler) sp.GetService<TModule>()
                    );
            }

            return this;
        }
    }
}

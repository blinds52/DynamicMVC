using System;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Practices.Unity;

namespace DynamicMVC.Shared
{
    public static class Container
    {
        public static T Resolve<T>(this IServiceProvider serviceProvider) where T : class
        {
            if (serviceProvider == null) throw new ArgumentNullException(nameof(serviceProvider));
            return serviceProvider.GetRequiredService<T>();
        }

        public static T Resolve<T>(this IServiceProvider serviceProvider, Type implemenType) where T : class
        {
            if (serviceProvider == null) throw new ArgumentNullException(nameof(serviceProvider));
            if (implemenType == null) throw new ArgumentNullException(nameof(implemenType));

            return (T) serviceProvider.GetRequiredService(implemenType);
        }
    }
}

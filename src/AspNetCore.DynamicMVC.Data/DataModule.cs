using System;
using AspNetCore.DynamicMVC.Porting;
using DynamicMVC.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Practices.Unity;

namespace DynamicMVC.Data
{
    public class DataModule :AspNetCoreModule
    {
        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IDynamicRepository, DynamicRepository>((sp) => new DynamicRepository(sp.GetService<ICreateDbContextManager>()));
        }

        public static void RegisterTypes(IServiceCollection serviceCollection)
        {
            if (serviceCollection == null) throw new ArgumentNullException(nameof(serviceCollection));
            RegisterTypes(serviceCollection.ToUnityContainer());
        }

    }
}

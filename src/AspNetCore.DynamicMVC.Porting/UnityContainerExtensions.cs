using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Practices.Unity
{
    /// <summary>
    /// Extension class that adds a set of convenience overloads to the
    ///             <see cref="T:Microsoft.Practices.Unity.IUnityContainer"/> interface.
    /// 
    /// </summary>
    public static class UnityContainerExtensions
    {
        internal class UnityContainerDecorator : IUnityContainer
        {
            internal IServiceCollection ServiceCollection { get; }

            public UnityContainerDecorator(IServiceCollection serviceCollection)
            {
                if (serviceCollection == null) throw new ArgumentNullException(nameof(serviceCollection));
                ServiceCollection = serviceCollection;
            }
        }

        public static IUnityContainer ToUnityContainer(this IServiceCollection serviceCollection)
        {
            if (serviceCollection == null) throw new ArgumentNullException(nameof(serviceCollection));
            return new UnityContainerDecorator(serviceCollection);
        }

        private static IServiceCollection ToServiceCollection(this IUnityContainer unityContainer)
        {
            if (unityContainer == null) throw new ArgumentNullException(nameof(unityContainer));
            return ((UnityContainerDecorator) unityContainer).ServiceCollection;
        }

        /// <summary>
        /// Register a type mapping with the container.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// This method is used to tell the container that when asked for type <paramref name="interfaceType"/>,
        ///             actually return an instance of type <paramref name="concreteType"/>. This is very useful for
        ///             getting instances of interfaces.
        /// 
        /// </remarks>
        /// <param name="container">Container to configure.</param>
        /// <param name="interfaceType"><see cref="T:System.Type"/> that will be requested.</param>
        /// <param name="concreteType"><see cref="T:System.Type"/> that will actually be returned.</param>
        /// <param name="name">Name to use for registration, null if a default registration.</param>
        /// <returns>
        /// The <see cref="T:Microsoft.Practices.Unity.UnityContainer"/> object that this method was called on (this in C#, Me in Visual Basic).
        /// </returns>
        public static IUnityContainer RegisterType(this IUnityContainer container, Type interfaceType, Type concreteType, string name)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));
            if (!string.IsNullOrWhiteSpace(name) && concreteType.Name != name)
            {
                throw new NotSupportedException();
            }
            container.ToServiceCollection().Add(new ServiceDescriptor(interfaceType, concreteType));
            return container;
        }

        /// <summary>
        /// Register a type mapping with the container, where the created instances will use
        ///             the given <see cref="T:Microsoft.Practices.Unity.LifetimeManager"/>.
        /// 
        /// </summary>
        /// <typeparam name="TInterfaceType"><see cref="T:System.Type"/> that will be requested.</typeparam>
        /// <typeparam name="TConcreteType"><see cref="T:System.Type"/> that will actually be returned.</typeparam>
        /// <param name="container">Container to configure.</param>
        /// <returns>
        /// The <see cref="T:Microsoft.Practices.Unity.UnityContainer"/> object that this method was called on (this in C#, Me in Visual Basic).
        /// </returns>
        public static IUnityContainer RegisterType<TInterfaceType, TConcreteType>(this IUnityContainer container) where TConcreteType : TInterfaceType
        {
            if (container == null) throw new ArgumentNullException(nameof(container));
            container.ToServiceCollection().Add(new ServiceDescriptor(typeof(TInterfaceType), typeof(TConcreteType)));
            return container;
        }

        public static IUnityContainer RegisterType<TInterfaceType, TConcreteType>(this IUnityContainer container, Func<IServiceProvider, TConcreteType> factory)
            where TInterfaceType : class 
            where TConcreteType  : class ,TInterfaceType
        {
            if (container == null) throw new ArgumentNullException(nameof(container));
            container.ToServiceCollection().Add(ServiceDescriptor.Scoped<TInterfaceType, TConcreteType>(factory));
            return container;
        }
    }
}

using System;
using AspNetCore.DynamicMVC.Porting;
using AspNetCore.DynamicMVC.UI.DynamicMVC.Factories;
using AspNetCore.DynamicMVC.UI.DynamicMVC.Interfaces;
using AspNetCore.DynamicMVC.UI.DynamicMVC.Managers;
using AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModelBuilders;
using DynamicMVC.DynamicEntityMetadataLibrary.Interfaces;
using DynamicMVC.Shared.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Practices.Unity;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC
{
    public class DynamicMVCModule : AspNetCoreModule
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here


            container.RegisterType<IDynamicCreateViewModelBuilder, DynamicCreateViewModelBuilder>();
            container.RegisterType<IDynamicDeleteViewModelBuilder, DynamicDeleteViewModelBuilder>();
            container.RegisterType<IDynamicEditViewModelBuilder, DynamicEditViewModelBuilder>();
            container.RegisterType<IDynamicDetailsViewModelBuilder, DynamicDetailsViewModelBuilder>();
            container.RegisterType<IDynamicIndexPageViewModelBuilder, DynamicIndexPageViewModelBuilder>();
            container.RegisterType<IDynamicIndexViewModelBuilder, DynamicIndexViewModelBuilder>();
            container.RegisterCollection<IDynamicEditorModelBuilder>();
            container.RegisterType<IDynamicFilterManager, DynamicFilterManager>();
            container.RegisterType<IDynamicFilterFactory, DynamicFilterFactory>();
            container.RegisterCollection<IDynamicDisplayPartialModelBuilder>();
            container.RegisterType<IRequestManager, RequestManager>();
            container.RegisterType<IDynamicEntitySearchManager, DynamicEntitySearchManager>();
            //container.RegisterType<IUrlManager, UrlManager>();
            container.RegisterType<IReturnUrlManager, ReturnUrlManager>();
            container.RegisterType<IDynamicMvcManager, DynamicMvcManager>();
            container.RegisterCollection<IDynamicFilter>();
            container.RegisterType<ISelectListItemManager, SelectListItemManager>();
            container.RegisterType<IPagingManager, PagingManager>();
            container.RegisterType<IDynamicPropertyViewModelBuilder, DynamicPropertyViewModelBuilder>();
            container.RegisterCollection<IDynamicMethodInvoker>(typeof(DynamicMVCModule).Assembly);
        }

        public static void RegisterTypes(IServiceCollection serviceCollection)
        {
            if (serviceCollection == null) throw new ArgumentNullException(nameof(serviceCollection));
            RegisterTypes(serviceCollection.ToUnityContainer());
        }

    }
}
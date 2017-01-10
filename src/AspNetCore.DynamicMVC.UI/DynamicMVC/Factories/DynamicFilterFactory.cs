using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCore.DynamicMVC.UI.DynamicMVC.Interfaces;
using DynamicMVC.Annotations;
using DynamicMVC.DynamicEntityMetadataLibrary.Models;
using DynamicMVC.Shared;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.Factories
{
    public class DynamicFilterFactory : IDynamicFilterFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDynamicFilter[] _dynamicFilters;

        public DynamicFilterFactory( IServiceProvider serviceProvider, IDynamicFilter[] dynamicFilters)
        {
            if (serviceProvider == null) throw new ArgumentNullException(nameof(serviceProvider));
            _serviceProvider = serviceProvider;
            _dynamicFilters = dynamicFilters;
        }

        private IDynamicFilter CreateDynamicFilter(string dynamicFilterViewName, DynamicPropertyMetadata dynamicPropertyMetadata, RouteValueDictionaryWrapper routeValueDictionaryWrapper)
        {
            var dynamicFilter = _dynamicFilters.SingleOrDefault(x => x.DynamicFilterViewName() == dynamicFilterViewName);
            if (dynamicFilter == null)
            {
                throw new Exception("Could not find Dynamic Filter for " + dynamicFilterViewName);
            }

            //ToDo:  this line was added due to unexpected data showing up in routevaluedictionary.
            //prevoius version used activator here.  look into removing this line
            dynamicFilter = _serviceProvider.Resolve<IDynamicFilter>(dynamicFilter.GetType());
            dynamicFilter.PropertyName = dynamicPropertyMetadata.PropertyName();
            dynamicFilter.RouteValueDictionaryWrapper = routeValueDictionaryWrapper;

            return dynamicFilter;
        }

        private void CallViewModelCreated(IDynamicFilter dynamicFilter, DynamicPropertyMetadata dynamicPropertyMetadata)
        {
            var controlParameters = (IDictionary<string, object>)new Dictionary<string, object>();
            if (dynamicPropertyMetadata.HasDynamicFilterUIAttribute())
                controlParameters = dynamicPropertyMetadata.GetDynamicFilterUIHintAttribute().ControlParameters;

            dynamicFilter.ViewModelCreated(dynamicPropertyMetadata, controlParameters);

        }
        public IDynamicFilter GetDynamicFilter(string dynamicFilterViewName, DynamicPropertyMetadata dynamicPropertyMetadata, RouteValueDictionaryWrapper routeValueDictionaryWrapper)
        {
            var dynamicFilter = CreateDynamicFilter(dynamicFilterViewName, dynamicPropertyMetadata, routeValueDictionaryWrapper);
            CallViewModelCreated(dynamicFilter, dynamicPropertyMetadata);
            return dynamicFilter;
        }

        public IDynamicFilter GetDynamicFilter(DynamicFilterUIHintAttribute dynamicFilterUIHintAttribute, DynamicPropertyMetadata dynamicPropertyMetadata, RouteValueDictionaryWrapper routeValueDictionaryWrapper)
        {            
            var dynamicFilter = CreateDynamicFilter(dynamicFilterUIHintAttribute.DynamicFilterViewName, dynamicPropertyMetadata, routeValueDictionaryWrapper);
            dynamicFilter.Order = dynamicPropertyMetadata.GetDynamicFilterUIHintAttribute().Order;
            CallViewModelCreated(dynamicFilter, dynamicPropertyMetadata);
            return dynamicFilter;
        }

    }
}
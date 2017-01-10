using DynamicMVC.Annotations;
using DynamicMVC.DynamicEntityMetadataLibrary.Models;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.Interfaces
{
    public interface IDynamicFilterFactory
    {
        IDynamicFilter GetDynamicFilter(string dynamicFilterViewName, DynamicPropertyMetadata dynamicPropertyMetadata, RouteValueDictionaryWrapper routeValueDictionaryWrapper);
        IDynamicFilter GetDynamicFilter(DynamicFilterUIHintAttribute dynamicFilterUIHintAttribute, DynamicPropertyMetadata dynamicPropertyMetadata, RouteValueDictionaryWrapper routeValueDictionaryWrapper);

    }
}
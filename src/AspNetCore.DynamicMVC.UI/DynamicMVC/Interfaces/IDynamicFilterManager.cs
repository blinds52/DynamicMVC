using System.Collections.Generic;
using AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels.DynamicPropertyViewModels;
using DynamicMVC.DynamicEntityMetadataLibrary.Models;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.Interfaces
{
    public interface IDynamicFilterManager
    {
        IEnumerable<DynamicFilterViewModel> GetFilterPropertyViewModels(DynamicEntityMetadata dynamicEntityMetadata, RouteValueDictionaryWrapper routeValueDictionaryWrapper);
        string GetFilterMessage(DynamicEntityMetadata dynamicEntityMetadata, RouteValueDictionaryWrapper routeValueDictionaryWrapper);
        IEnumerable<IDynamicFilter> GetDynamicFilters(DynamicEntityMetadata dynamicEntityMetadata, RouteValueDictionaryWrapper routeValueDictionaryWrapper);
    }
}
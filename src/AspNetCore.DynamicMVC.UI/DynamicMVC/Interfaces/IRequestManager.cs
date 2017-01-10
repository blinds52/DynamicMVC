using System.Collections.Generic;
using DynamicMVC.DynamicEntityMetadataLibrary.Models;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.Interfaces
{
    public interface IRequestManager
    {
        IDictionary<string, object> RouteDataDictionary { get; set; }
        RouteValueDictionaryWrapper QueryStringDictionary { get; set; }
        void CorrectQuerystringTypes(DynamicEntityMetadata dynamicEntityMetadata);
        bool PagingParametersDoNotExist();
        void AddPagingParameters(string defaultOrderBy, int page, int pageSize, string keyName);
        RouteValueDictionaryWrapper RouteValueDictionaryWrapper();
        string OrderBy();
        string ViewProperties();
    }
}
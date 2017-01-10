using System.Linq;
using AspNetCore.DynamicMVC.UI.DynamicMVC.Interfaces;
using AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels;
using AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels.Partials;
using DynamicMVC.DynamicEntityMetadataLibrary.Models;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModelBuilders
{
    public class DynamicIndexViewModelBuilder : IDynamicIndexViewModelBuilder
    {
        private readonly IRequestManager _requestManager;
        private readonly IDynamicFilterManager _dynamicFilterManager;

        public DynamicIndexViewModelBuilder(IRequestManager requestManager, IDynamicFilterManager dynamicFilterManager)
        {
            _requestManager = requestManager;
            _dynamicFilterManager = dynamicFilterManager;
        }

        public DynamicIndexViewModel Build(DynamicEntityMetadata dynamicEntityMetadata)
        {
            var dynamicIndexViewModel = new DynamicIndexViewModel();
            var routeValueDictionary = _requestManager.QueryStringDictionary;
            _requestManager.CorrectQuerystringTypes(dynamicEntityMetadata);
            dynamicIndexViewModel.RouteValueDictionaryWrapper = routeValueDictionary;
            dynamicIndexViewModel.Header = dynamicEntityMetadata.IndexHeader();
            dynamicIndexViewModel.TypeName = dynamicEntityMetadata.TypeName();
            dynamicIndexViewModel.FilterMessage = _dynamicFilterManager.GetFilterMessage(dynamicEntityMetadata, routeValueDictionary);

            var filters = _dynamicFilterManager.GetFilterPropertyViewModels(dynamicEntityMetadata, routeValueDictionary).ToList();
            dynamicIndexViewModel.DynamicIndexFiltersViewModel = new DynamicIndexFiltersViewModel(dynamicEntityMetadata.TypeName(), routeValueDictionary, filters);

            return dynamicIndexViewModel;
        }

    }
}

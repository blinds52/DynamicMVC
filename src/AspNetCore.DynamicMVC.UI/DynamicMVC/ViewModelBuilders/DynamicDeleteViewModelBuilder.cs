using AspNetCore.DynamicMVC.UI.DynamicMVC.Interfaces;
using AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels;
using DynamicMVC.DynamicEntityMetadataLibrary.Models;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModelBuilders
{
    public class DynamicDeleteViewModelBuilder : IDynamicDeleteViewModelBuilder
    {
        public DynamicDeleteViewModel Build(DynamicEntityMetadata dynamicEntityMetadata, dynamic deleteModel, string returnUrl)
        {
            var dynamicDeleteViewModel = new DynamicDeleteViewModel();
            dynamicDeleteViewModel.TypeName = dynamicEntityMetadata.TypeName();
            dynamicDeleteViewModel.Header = "Delete " + dynamicEntityMetadata.TypeName();
            dynamicDeleteViewModel.ReturnUrl = returnUrl;
            return dynamicDeleteViewModel;
        }
    }
}

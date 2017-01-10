using AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels;
using DynamicMVC.DynamicEntityMetadataLibrary.Models;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.Interfaces
{
    public interface IDynamicEditViewModelBuilder
    {
        DynamicEditViewModel Build(DynamicEntityMetadata dynamicEntityMetadata, dynamic editModel, string returnUrl);
    }
}
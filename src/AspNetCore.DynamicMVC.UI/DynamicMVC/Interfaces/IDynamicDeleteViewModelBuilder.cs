using AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels;
using DynamicMVC.DynamicEntityMetadataLibrary.Models;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.Interfaces
{
    public interface IDynamicDeleteViewModelBuilder
    {
        DynamicDeleteViewModel Build(DynamicEntityMetadata dynamicEntityMetadata, dynamic deleteModel, string returnUrl);
    }
}
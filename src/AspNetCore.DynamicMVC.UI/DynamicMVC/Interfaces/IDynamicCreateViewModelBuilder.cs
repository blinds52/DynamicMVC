using AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels;
using DynamicMVC.DynamicEntityMetadataLibrary.Models;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.Interfaces
{
    public interface IDynamicCreateViewModelBuilder
    {
        DynamicCreateViewModel Build(DynamicEntityMetadata dynamicEntityMetadata, dynamic createModel, string returnUrl);
    }
}
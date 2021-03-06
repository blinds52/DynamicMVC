using AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels;
using DynamicMVC.DynamicEntityMetadataLibrary.Models;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.Interfaces
{
    public interface IDynamicDetailsViewModelBuilder
    {
        DynamicDetailsViewModel Build(DynamicEntityMetadata dynamicEntityMetadata, dynamic detailModel);
    }
}
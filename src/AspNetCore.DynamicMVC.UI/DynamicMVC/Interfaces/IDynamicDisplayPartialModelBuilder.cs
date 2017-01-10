using AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels.DynamicPropertyViewModels;
using DynamicMVC.DynamicEntityMetadataLibrary.Models;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.Interfaces
{
    public interface IDynamicDisplayPartialModelBuilder
    {
        string DynamicDisplayPartialName();
        void Build(DynamicPropertyMetadata dynamicPropertyMetadata, DynamicPropertyIndexViewModel dynamicPropertyIndexViewModel, dynamic item);
    }
}
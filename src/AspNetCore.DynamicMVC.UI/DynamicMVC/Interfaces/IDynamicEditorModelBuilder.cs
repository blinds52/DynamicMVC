using AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels.DynamicPropertyViewModels;
using DynamicMVC.DynamicEntityMetadataLibrary.Models;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.Interfaces
{
    public interface IDynamicEditorModelBuilder
    {
        string DynamicEditorName();
        void Build(DynamicPropertyMetadata dynamicPropertyMetadata, DynamicPropertyEditorViewModel dynamicPropertyViewModel, dynamic item);
    }
}
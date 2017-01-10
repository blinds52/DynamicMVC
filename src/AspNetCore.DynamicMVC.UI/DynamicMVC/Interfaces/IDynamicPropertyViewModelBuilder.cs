using AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels.DynamicPropertyViewModels;
using DynamicMVC.DynamicEntityMetadataLibrary.Models;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.Interfaces
{
    public interface IDynamicPropertyViewModelBuilder
    {
        DynamicPropertyIndexViewModel BuildDynamicPropertyIndexViewModel(DynamicPropertyMetadata dynamicPropertyMetadata);
        DynamicPropertyEditorViewModel BuildDynamicPropertyEditorViewModelForEdit(DynamicPropertyMetadata dynamicPropertyMetadata);
        DynamicPropertyEditorViewModel BuildDynamicPropertyEditorViewModelForCreate(DynamicPropertyMetadata dynamicPropertyMetadata);
        DynamicPropertyEditorViewModel BuildDynamicPropertyEditorViewModelForDetails(DynamicPropertyMetadata dynamicPropertyMetadata);
    }
}
using AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels.DynamicEditorViewModels;
using DynamicMVC.DynamicEntityMetadataLibrary.Models;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels.DynamicPropertyViewModels
{
    public class DynamicPropertyEditorViewModel : DynamicPropertyViewModel
    {
        public DynamicPropertyEditorViewModel(DynamicPropertyMetadata dynamicPropertyMetadata) : base(dynamicPropertyMetadata)
        {
            
        }

        public string DynamicEditorName { get; set; }
        public DynamicEditorHyperlinkViewModel DynamicEditorHyperlinkViewModel { get; set; }
        public DynamicEditorDropDownViewModel DynamicEditorDropDownViewModel { get; set; }
        public DynamicEditorAutoCompleteViewModel DynamicEditorAutoCompleteViewModel { get; set; }
    }
}
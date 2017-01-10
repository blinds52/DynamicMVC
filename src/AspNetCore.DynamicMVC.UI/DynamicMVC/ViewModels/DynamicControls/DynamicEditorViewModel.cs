using AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels.DynamicPropertyViewModels;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels.DynamicControls
{
    public class DynamicEditorViewModel
    {
        public string ViewModelPropertyName { get; set; }
        public string DynamicEditorName { get; set; }
        public DynamicPropertyEditorViewModel DynamicPropertyEditorViewModel { get; set; }
    }
}

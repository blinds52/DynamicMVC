using System.Collections.Generic;
using AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels.DynamicControls;
using DynamicMVC.DynamicEntityMetadataLibrary.Models;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels
{
    public class DynamicDetailsViewModel
    {
        public DynamicDetailsViewModel()
        {
            Title = "Details";
            DynamicEditorViewModels = new HashSet<DynamicEditorViewModel>();
            DynamicUIMethods = new HashSet<DynamicMethod>();
        }

        public string Title { get; set; }
        public string Header { get; set; }
        public string TypeName { get; set; }
        public dynamic Item { get; set; }

        public ICollection<DynamicEditorViewModel> DynamicEditorViewModels { get; set; }
        public ICollection<DynamicMethod> DynamicUIMethods { get; set; }
    }
}

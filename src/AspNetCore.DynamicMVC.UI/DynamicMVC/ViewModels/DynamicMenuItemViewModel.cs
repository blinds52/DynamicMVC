using System.Collections.Generic;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels
{
    public class DynamicMenuItemViewModel
    {
        public DynamicMenuItemViewModel()
        {
            DynamicMenuItemViewModels = new List<DynamicMenuItemViewModel>();
        }
        public DynamicMenuItemViewModel(string displayName)
            : this()
        {
            DisplayName = displayName;
        }
        public DynamicMenuItemViewModel(global::DynamicMVC.DynamicEntityMetadataLibrary.Models.DynamicEntityMetadata dynamicEntityMetadata)
            : this()
        {
            DynamicEntityMetadata = dynamicEntityMetadata;
        }
        public DynamicMenuItemViewModel(global::DynamicMVC.DynamicEntityMetadataLibrary.Models.DynamicEntityMetadata dynamicEntityMetadata, string displayName)
            : this(dynamicEntityMetadata)
        {
            DisplayName = displayName;
        }

        public global::DynamicMVC.DynamicEntityMetadataLibrary.Models.DynamicEntityMetadata DynamicEntityMetadata { get; set; }
        public string DisplayName { get; set; }

        public List<DynamicMenuItemViewModel> DynamicMenuItemViewModels { get; set; }
    }
}

using AspNetCore.DynamicMVC.UI.DynamicMVC.Interfaces;
using DynamicMVC.DynamicEntityMetadataLibrary.Models;

#pragma warning disable 1591

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels.DynamicPropertyViewModels
{
    public class DynamicPropertyViewModel : IDynamicDisplayName
    {
        public DynamicPropertyViewModel(DynamicPropertyMetadata dynamicPropertyMetadata)
        {
            ViewModelPropertyName = dynamicPropertyMetadata.PropertyName();
            PropertyName = dynamicPropertyMetadata.PropertyName();
            DisplayName = dynamicPropertyMetadata.DisplayName();
        }

        public string ViewModelPropertyName { get; set; }
        public string PropertyName { get; set; }
        public string DisplayName { get; set; }
    }
}

using AspNetCore.DynamicMVC.UI.DynamicMVC.Interfaces;
using DynamicMVC.DynamicEntityMetadataLibrary.Models;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels.DynamicPropertyViewModels
{
    public class DynamicFilterViewModel : DynamicPropertyViewModel
    {

        public DynamicFilterViewModel(DynamicPropertyMetadata dynamicPropertyMetadata) : base(dynamicPropertyMetadata)
        {
        }

        public string DynamicFilterViewName { get; set; }
        public IDynamicFilter FilterModel { get; set; }
    }
}
using System.Collections.Generic;
using AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels.DynamicPropertyViewModels;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.ViewModels
{
    public class DynamicIndexItemViewModel
    {
        public DynamicIndexItemViewModel()
        {
            DynamicPropertyIndexViewModels = new List<DynamicPropertyIndexViewModel>();
        }

        public bool ShowDelete { get; set; }
        public bool ShowEdit { get; set; }
        public bool ShowDetails { get; set; }
        public dynamic Item { get; set; }
        public string TypeName { get; set; }
        public RouteValueDictionaryWrapper RouteValueDictionaryWrapper { get; set; }
        
        public List<DynamicPropertyIndexViewModel> DynamicPropertyIndexViewModels { get; set; }
    }
}

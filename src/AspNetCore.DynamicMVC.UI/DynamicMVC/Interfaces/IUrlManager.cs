using Microsoft.AspNetCore.Mvc.Routing;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.Interfaces
{
    public interface IUrlManager
    {
        UrlHelper Url { get; set; }
    }
}
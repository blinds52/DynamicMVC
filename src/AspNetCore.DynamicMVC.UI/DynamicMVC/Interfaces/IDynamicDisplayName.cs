#pragma warning disable 1591
namespace AspNetCore.DynamicMVC.UI.DynamicMVC.Interfaces
{
    public interface IDynamicDisplayName
    {
        string DisplayName { get; set; }
        string ViewModelPropertyName { get; set; }
    }
}

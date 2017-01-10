using DynamicMVC.DynamicEntityMetadataLibrary.Models;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC.Interfaces
{
    public interface IDynamicEntitySearchManager
    {
        DynamicEntityMetadata DynamicEntityMetadata { get; }
    }
}
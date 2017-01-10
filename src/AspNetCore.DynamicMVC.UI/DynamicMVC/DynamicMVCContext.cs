using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCore.DynamicMVC.UI.DynamicMVC.Interfaces;
using DynamicMVC.DynamicEntityMetadataLibrary.Models;

namespace AspNetCore.DynamicMVC.UI.DynamicMVC
{
    public static class DynamicMVCContext
    {
        static DynamicMVCContext()
        {
            Options = new DynamicMVCContextOptions();
        }

        public static DynamicMVCContextOptions Options { get; set; }

        public static IEnumerable<DynamicEntityMetadata> DynamicEntityMetadatas { get; set; }
        
        public static IEnumerable<Type> DynamicFilterViewModels { get; set; }

        public static global::DynamicMVC.DynamicEntityMetadataLibrary.Models.DynamicEntityMetadata GetDynamicEntityMetadata(string typeName)
        {
            return DynamicEntityMetadatas.Single(x => x.TypeName() == typeName);
        }

        public static IDynamicMvcManager DynamicMvcManager;
    }
}

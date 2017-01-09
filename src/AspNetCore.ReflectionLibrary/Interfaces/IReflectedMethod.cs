using System;
using System.Collections.Generic;

namespace ReflectionLibrary.Interfaces
{
    /// <summary>
    /// Shows All Information for MethodInfo
    /// </summary>
    public interface IReflectedMethod : IReflectedObjectWithAttributes
    {
        /// <summary>
        /// Parent Class
        /// </summary>
        IReflectedClass ReflectedClass { get; set; }
        IReflectedMethodOperations ReflectedMethodOperations { get; set; }
    }
}

using System;

namespace DynamicLinqExtensions
{
    public class DynamicLinqExtensionsException : Exception
    {
        public DynamicLinqExtensionsException(string message)
            : base(message)
        {
        }
    }
}
using System;
using System.Collections.Generic;
using ReflectionLibrary.Interfaces;

namespace ReflectionLibrary.Models
{
    public class ReflectedMethod : IReflectedMethod
    {

        public ReflectedMethod()
        {
            Attributes = new HashSet<Attribute>();
        } 

        public string Name { get; set; }
        
        public IReflectedClass ReflectedClass { get; set; }
        public ICollection<Attribute> Attributes { get; set; }
        public IReflectedMethodOperations ReflectedMethodOperations { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Attributes.Count} Attributes";
        }
    }
}

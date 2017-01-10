using System.Linq.Expressions;

namespace DynamicLinqExtensions
{
    internal class DynamicOrdering
    {
        public Expression Selector;
        public bool Ascending;
    }
}
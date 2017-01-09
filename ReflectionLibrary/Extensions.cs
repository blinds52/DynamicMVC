using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class Extensions
    {
        public static IEnumerable<TResult> ForEach<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> method)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (method == null) throw new ArgumentNullException(nameof(method));

            return source.Select(method);
        }
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Func<T, T> method)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (method == null) throw new ArgumentNullException(nameof(method));

            return source.Select(method);
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> method)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (method == null) throw new ArgumentNullException(nameof(method));

            foreach (var item in source)
            {
                method(item);
            }
        }
    }
}

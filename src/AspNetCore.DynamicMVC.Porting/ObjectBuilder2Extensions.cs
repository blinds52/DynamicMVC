using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Practices.ObjectBuilder2
{
    /// <summary>
    /// The almost inevitable collection of extra helper methods on
    ///             <see cref="T:System.Collections.Generic.IEnumerable`1"/> to augment the rich set of what
    ///             LINQ already gives us.
    /// 
    /// </summary>
    public static class ObjectBuilder2Extensions
    {
        /// <summary>
        /// Execute the provided <paramref name="action"/> on every item in <paramref name="sequence"/>.
        /// 
        /// </summary>
        /// <typeparam name="TItem">Type of the items stored in <paramref name="sequence"/></typeparam><param name="sequence">Sequence of items to process.</param><param name="action">Code to run over each item.</param>
        public static void ForEach<TItem>(this IEnumerable<TItem> sequence, Action<TItem> action)
        {
            if (sequence == null) throw new ArgumentNullException(nameof(sequence));
            foreach (TItem obj in sequence)
                action(obj);
        }

        /// <summary>
        /// Create a single string from a sequence of items, separated by the provided <paramref name="separator"/>,
        ///             and with the conversion to string done by the given <paramref name="converter"/>.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// This method does basically the same thing as <see cref="M:System.String.Join(System.String,System.String[])"/>,
        ///             but will work on any sequence of items, not just arrays.
        /// </remarks>
        /// <typeparam name="TItem">Type of items in the sequence.</typeparam><param name="sequence">Sequence of items to convert.</param><param name="separator">Separator to place between the items in the string.</param><param name="converter">The conversion function to change TItem -&gt; string.</param>
        /// <returns>
        /// The resulting string.
        /// </returns>
        public static string JoinStrings<TItem>(this IEnumerable<TItem> sequence, string separator, Func<TItem, string> converter)
        {
            StringBuilder seed = new StringBuilder();
            Enumerable.Aggregate<TItem, StringBuilder>(sequence, seed, (Func<StringBuilder, TItem, StringBuilder>)((builder, item) =>
            {
                if (builder.Length > 0)
                    builder.Append(separator);
                builder.Append(converter(item));
                return builder;
            }));
            return seed.ToString();
        }

        /// <summary>
        /// Create a single string from a sequence of items, separated by the provided <paramref name="separator"/>,
        ///             and with the conversion to string done by the item's <see cref="M:System.Object.ToString"/> method.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// This method does basically the same thing as <see cref="M:System.String.Join(System.String,System.String[])"/>,
        ///             but will work on any sequence of items, not just arrays.
        /// </remarks>
        /// <typeparam name="TItem">Type of items in the sequence.</typeparam><param name="sequence">Sequence of items to convert.</param><param name="separator">Separator to place between the items in the string.</param>
        /// <returns>
        /// The resulting string.
        /// </returns>
        public static string JoinStrings<TItem>(this IEnumerable<TItem> sequence, string separator)
        {
            return JoinStrings<TItem>(sequence, separator, (Func<TItem, string>)(item => item.ToString()));
        }
    }

}

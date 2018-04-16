using System;
using System.Collections;
using System.Collections.Generic;

namespace NumberOperations
{
    /// <summary>
    /// This class is responsible for filtering the array by the criterion.
    /// </summary>
    public static class ArrayFilter
    {
        /// <summary>
        /// Filter for collections
        /// </summary>
        /// <typeparam name="T">type of collections data</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>filtered collection</returns>
        /// <exception cref="ArgumentNullException">
        /// collection is null
        /// or
        /// filter is null
        /// </exception>
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, IFilter<T> filter)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            return Filter<T>(collection, filter.IsMatch);
        }

        /// <summary>
        /// Filter for collections
        /// </summary>
        /// <typeparam name="T">type of collections data</typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>filtered collection</returns>
        /// <exception cref="ArgumentNullException">
        /// collection is null
        /// or
        /// filter is null
        /// </exception>
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Func<T, bool> filter)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            foreach (T item in collection)
            {
                if (filter(item))
                {
                    yield return item;
                }
            }
        }
    }
}

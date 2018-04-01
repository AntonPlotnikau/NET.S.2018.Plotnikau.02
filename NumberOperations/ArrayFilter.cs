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
        /// This method returns the numeric array that contains only numbers with a given digit.
        /// </summary>
        /// <param name="array">The source array for filtering.</param>
        /// <param name="filter">Filtering criteria.</param>
        /// <returns>
        /// Filtered array.
        /// </returns>
        /// <exception cref="ArgumentNullException">array is null or filter is null</exception>
        public static int[] FilterDigit(int[] array, IFilter<int> filter)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            var list = new List<int>();
            for (int i = 0; i < array.Length; i++) 
            {
                if (filter.IsMatch(array[i])) 
                {
                    list.Add(array[i]);
                }
            }

            return list.ToArray();
        }
    }
}

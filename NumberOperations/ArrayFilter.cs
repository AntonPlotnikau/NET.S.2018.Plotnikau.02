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
        /// <returns>Filtered array.</returns>
        public static int[] FilterDigit(int[] array, int filter)
        {
            if (array == null) 
            {
                throw new ArgumentNullException();
            }

            var list = new List<int>();
            for (int i = 0; i < array.Length; i++) 
            {
                if (IsFits(array[i], filter)) 
                {
                    list.Add(array[i]);
                }
            }

            return list.ToArray();
        }

        /// <summary>
        /// Checks whether an array element matches a given criterion.
        /// </summary>
        /// <param name="number">An array element.</param>
        /// <param name="filter">Filter criteria</param>
        /// <returns>true, if element suits for the specified criterion, or false, if doesn't suit</returns>
        private static bool IsFits(int number, int filter)
        {
            do
            {
                if (number % 10 == filter || number % 10 == -filter) 
                {
                    return true;
                }

                number /= 10;
            }
            while (number != 0);

            return false;
        }
    }
}

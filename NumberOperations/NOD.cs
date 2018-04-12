using System;

namespace NumberOperations
{
    /// <summary>
    /// Calculate NOD
    /// </summary>
    public static class NOD
    {
        #region EuclidAlgorithm

        /// <summary>
        /// Euclid's Algorithm of NOD calculating.
        /// </summary>
        /// <param name="value1">First value.</param>
        /// <param name="value2">Second value.</param>
        /// <returns>NOD of two values</returns>
        public static int EuclidAlgorithm(int value1, int value2)
        {
            value1 = Math.Abs(value1);  
            value2 = Math.Abs(value2);

            while ((value1 != 0) && (value2 != 0))
            {
                if (value1 > value2)
                {
                    value1 -= value2;
                }
                else
                {
                    value2 -= value1;
                }
            }

            return Math.Max(value1, value2);
        }

        /// <summary>
        /// Euclid's Algorithm of NOD calculating.
        /// </summary>
        /// <param name="value1">First value.</param>
        /// <param name="value2">Second value.</param>
        /// <param name="value3">Third value.</param>
        /// <returns>NOD of this values</returns>
        public static int EuclidAlgorithm(int value1, int value2, int value3)
            => FindNOD(EuclidAlgorithm, value1, value2, value3);

        /// <summary>
        /// Euclid's Algorithm of NOD calculating.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>NOD of few values</returns>
        public static int EuclidAlgorithm(params int[] values)
            => FindNOD(EuclidAlgorithm, values);

        #endregion

        #region SteinAlgorithm

        /// <summary>
        /// Stein's Algorithm of NOD calculating.
        /// </summary>
        /// <param name="value1">First value.</param>
        /// <param name="value2">Second value.</param>
        /// <returns>NOD of two values</returns>
        public static int SteinAlgorithm(int value1, int value2)
        {
            value1 = Math.Abs(value1);
            value2 = Math.Abs(value2);

            if (value1 == 0)
            {
                return value2;
            }

            if (value2 == 0)
            {
                return value1;
            }

            if (value1 == value2)
            {
                return value1;
            }

            if (value1 % 2 == 0 && value2 % 2 == 0)
            {
                return 2 * SteinAlgorithm(value1 / 2, value2 / 2);
            }
            else if (value1 % 2 == 0)
            {
                return SteinAlgorithm(value1 / 2, value2);
            }
            else if (value2 % 2 == 0) 
            {
                return SteinAlgorithm(value1, value2 / 2);
            }
            else if (value1 > value2)
            {
                return SteinAlgorithm((value1 - value2) / 2, value2);
            }
            else
            {
                return SteinAlgorithm(value1, (value2 - value1) / 2);
            }
        }

        /// <summary>
        /// Stein's Algorithm of NOD calculating.
        /// </summary>
        /// <param name="value1">First value.</param>
        /// <param name="value2">Second value.</param>
        /// <param name="value3">Third value.</param>
        /// <returns>NOD of this values</returns>
        public static int SteinAlgorithm(int value1, int value2, int value3)
            => FindNOD(SteinAlgorithm, value1, value2, value3);

        /// <summary>
        /// Stein's Algorithm of NOD calculating.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>NOD of few values</returns>
        public static int SteinAlgorithm(params int[] values)
            => FindNOD(SteinAlgorithm, values);
        #endregion

        #region Private Methods
        /// <summary>
        /// Finds the nod.
        /// </summary>
        /// <param name="nod">The nod.</param>
        /// <param name="values">The values.</param>
        /// <returns>nod of few values</returns>
        /// <exception cref="ArgumentNullException">
        /// nod is null
        /// or
        /// values is null
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">values is less than two</exception>
        private static int FindNOD(Func<int, int, int> nod, params int[] values)
        {
            if (nod == null)
            {
                throw new ArgumentNullException(nameof(nod));
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.Length < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(values));
            }

            int result = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                result = nod(result, values[i]);
            }

            return result;
        }

        /// <summary>
        /// Finds the nod.
        /// </summary>
        /// <param name="nod">The nod.</param>
        /// <param name="value1">The value1.</param>
        /// <param name="value2">The value2.</param>
        /// <param name="value3">The value3.</param>
        /// <returns>nod of three values</returns>
        /// <exception cref="ArgumentNullException">nod is null</exception>
        private static int FindNOD(Func<int, int, int> nod, int value1, int value2, int value3)
        {
            if (nod == null)
            {
                throw new ArgumentNullException(nameof(nod));
            }

            return nod(nod(value1, value2), value3);
        }
        #endregion
    }
}

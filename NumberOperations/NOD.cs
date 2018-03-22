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
        {
            int divider = EuclidAlgorithm(value1, value2);

            return EuclidAlgorithm(divider, value3);
        }

        /// <summary>
        /// Euclid's Algorithm of NOD calculating.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>NOD of few values</returns>
        /// <exception cref="ArgumentNullException">values is null reference</exception>
        /// <exception cref="ArgumentOutOfRangeException">values is null reference</exception>
        public static int EuclidAlgorithm(params int[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.Length < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(values));
            }

            int divider = values[0];
            for (int i = 1; i < values.Length; i++) 
            {
                divider = EuclidAlgorithm(divider, values[i]);
            }

            return divider;
        }

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
        {
            int divider = SteinAlgorithm(value1, value2);

            return SteinAlgorithm(divider, value3);
        }

        /// <summary>
        /// Stein's Algorithm of NOD calculating.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>NOD of few values</returns>
        /// <exception cref="ArgumentNullException">values is null reference</exception>
        /// <exception cref="ArgumentOutOfRangeException">values is null reference</exception>
        public static int SteinAlgorithm(params int[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.Length < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(values));
            }

            int divider = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                divider = SteinAlgorithm(divider, values[i]);
            }

            return divider;
        }
        #endregion
    }
}

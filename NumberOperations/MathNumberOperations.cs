using System;

namespace NumberOperations
{
    /// <summary>
    /// represent different math operations with numbers
    /// </summary>
    public static class MathNumberOperations
    {
        /// <summary>
        /// Finds the NTH root.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="rootDegree">The root degree.</param>
        /// <param name="precision">The precision.</param>
        /// <returns>NTH Root of the number</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// rootDegree less than or equal to zero
        /// or
        /// precision less than or equal to zero
        /// </exception>
        public static double FindNthRoot(double number, int rootDegree, double precision)
        {
            if (rootDegree <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rootDegree));
            }

            if (precision <= 0) 
            {
                throw new ArgumentOutOfRangeException(nameof(precision));
            }

            if (number == 0 || number == 1)
            {
                return number;
            }

            double root = ((rootDegree - 1) + number) / rootDegree;
            double x = 1;
            while (Math.Abs(root - x) > precision) 
            {
                x = root;
                root = (((rootDegree - 1) * x) + (number / Math.Pow(x, rootDegree - 1))) / rootDegree;
            }

            return root;
        }

        /// <summary>
        /// Inserts the bits from one number to another.
        /// </summary>
        /// <param name="numberSource">Source number.</param>
        /// <param name="numberln">Second number.</param>
        /// <param name="firstBit">The first bit of the second number.</param>
        /// <param name="secondBit">The second bit of the second number.</param>
        /// <returns>source number with copied bits from the second number</returns>
        public static int InsertNumber(int numberSource, int numberln, int firstBit, int secondBit)
        {
            if (firstBit > secondBit) 
            {
                throw new ArgumentOutOfRangeException(nameof(firstBit));
            }

            if ((firstBit >= 0 && firstBit <= 31) == false) 
            {
                throw new ArgumentOutOfRangeException(nameof(firstBit));
            }

            if ((secondBit >= 0 && secondBit <= 31) == false) 
            {
                throw new ArgumentOutOfRangeException(nameof(secondBit));
            }

            int[] numberSourceArray = ConvertToBinaryArray(numberSource);
            int[] numberlnArray = ConvertToBinaryArray(numberln);

            for (int i = firstBit, j = 0; i <= secondBit; i++, j++) 
            {
                numberSourceArray[i] = numberlnArray[j];
            }

            return ConvertFromBinaryArray(numberSourceArray);
        }

        /// <summary>
        /// Finds the next bigger number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>next bigger number with the sum of the digits of this number</returns>
        /// <exception cref="ArgumentOutOfRangeException">number not positive</exception>
        public static int FindNextBiggerNumber(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }

            char[] array = number.ToString().ToCharArray();
            for (int i = array.Length - 1; i - 1 >= 0; i--) 
            {
                if (array[i] > array[i - 1]) 
                {
                    char temp = array[i];
                    array[i] = array[i - 1];
                    array[i - 1] = temp;
                    Array.Sort(array, i, array.Length - i);
                    break;
                }
            }

            string foundedNumber = new string(array);
            if (number == int.Parse(foundedNumber))
            {
                return -1;
            }

            return int.Parse(foundedNumber);
        }

        /// <summary>
        /// Finds the next bigger number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="time">time of finding the number</param>
        /// <returns>next bigger number with the sum of the digits of this number</returns>
        public static int FindNextBiggerNumber(int number, out long time)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            number = FindNextBiggerNumber(number);
            watch.Stop();
            time = watch.ElapsedMilliseconds;
            return number;
        }

        /// <summary>
        /// To the binary array.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Array that represent byte code of the number</returns>
        private static int[] ConvertToBinaryArray(int number)
        {
            int[] array = new int[32];
            if (number < 0)
            {
                array[31] = 1;
                number *= -1;
            }

            for (int i = 0; number != 0; i++)
            {
                array[i] = number % 2;
                number /= 2;
            }

            return array;
        }

        /// <summary>
        /// From the binary array.
        /// </summary>
        /// <param name="array">Byte code array.</param>
        /// <returns>number that was converted from byte code array</returns>
        private static int ConvertFromBinaryArray(int[] array)
        {
            int number = 0;
            for (int i = 0; i < 31; i++)
            {
                number += array[i] * (int)Math.Pow(2, i);
            }

            if (array[31] == 1)
            {
                number *= -1;
            }

            return number;
        }
    }
}

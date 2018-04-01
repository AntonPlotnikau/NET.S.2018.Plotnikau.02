using System;

namespace NumberOperations
{
    /// <summary>
    /// digit filter
    /// </summary>
    /// <seealso cref="NumberOperations.IFilter{System.Int32}" />
    public class DigitFilter : IFilter<int>
    {
        /// <summary>
        /// The filter
        /// </summary>
        private int filter;

        /// <summary>
        /// Initializes a new instance of the <see cref="DigitFilter"/> class.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <exception cref="ArgumentOutOfRangeException">filter is not a digit</exception>
        public DigitFilter(int filter)
        {
            if (filter < 0 || filter > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(filter));
            }

            this.filter = filter;
        }

        /// <summary>
        /// Determines whether the specified number is match filter.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///   <c>true</c> if the specified number is match filter; otherwise, <c>false</c>.
        /// </returns>
        public bool IsMatch(int number)
        {
            do
            {
                if (number % 10 == this.filter || number % 10 == -this.filter)
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

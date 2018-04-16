using System;
using System.Collections.Generic;
using NumberOperations;
using NUnit.Framework;

namespace NumberOperationsNUnit.Tests
{
    /// <summary>
    /// Tests ArrayFilter using NUnit framework
    /// </summary>
    [TestFixture]
    public class ArrayFilterNUnitTests
    {
        /// <summary>
        /// test for FilterDigit method.
        /// </summary>
        /// <param name="source">source array for filtering</param>
        /// <param name="expected">expected array after filtering</param>
        /// <param name="filter">filtering criteria</param>
        [Test]
        [TestCase(new int[] { 6, 5, 4 }, new int[] { }, 7)]
        [TestCase(new int[] { 32, -3, 45, 56, 73, 33, 0 }, new int[] { 32, -3, 73, 33 }, 3)]
        [TestCase(new int[] { 94, -3, 29, 51, 9, -19, 4 }, new int[] { 94, 29, 9, -19 }, 9)]
        public void FilterDigit_UnfilteredArray_FilteredArray(int[] source, int[] expected, int filter)
        {
            IEnumerable<int> actual = ArrayFilter.Filter(source, new DigitFilter(filter));

            int i = -1;
            foreach (int item in actual)
            {
                Assert.AreEqual(expected[++i], item);
            }
        }

        /// <summary>
        /// Tests generation of ArgumentNullException
        /// </summary>
        [Test]
        public void FilterDigit_WithNull_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => ArrayFilter.Filter(null, new DigitFilter(3)));
    }
}

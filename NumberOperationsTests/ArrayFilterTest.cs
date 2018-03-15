using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberOperations;

namespace NumberOperationsTests
{
    /// <summary>
    /// Tests ArrayFilter using MS Test
    /// </summary>
    [TestClass]
    public class ArrayFilterTest
    {
        /// <summary>
        /// Tests FilterDigit method. This method uses AAA technology.
        /// </summary>
        [TestMethod]
        public void FilterDigit_UnfilteredArray_FilteredArray()
        {
            int[] sourceArray = { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            int[] expectedArray = { 7, 7, 70, 17 };

            int[] actual = ArrayFilter.FilterDigit(sourceArray, 7);

            CollectionAssert.AreEqual(expectedArray, actual);
        }
    }
}

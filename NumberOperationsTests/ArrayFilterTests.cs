using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberOperations.Tests
{
    /// <summary>
    /// Tests ArrayFilter using MS Test
    /// </summary>
    [TestClass]
    public class ArrayFilterTests
    {
        /// <summary>
        /// Gets or sets data from xml file
        /// </summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// Tests FilterDigit method. This method uses AAA technology.
        /// </summary>
        [TestMethod]
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\ArrayFilterTestsData.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        public void FilterDigit_UnfilteredArray_FilteredArray()
        {
            int[] source = Array.ConvertAll(Convert.ToString(TestContext.DataRow["Actual"]).Split(' '), int.Parse);
            int[] expected = Array.ConvertAll(Convert.ToString(TestContext.DataRow["ExpectedResult"]).Split(' '), int.Parse);
            var filter = Convert.ToInt32(TestContext.DataRow["Filter"]);

            int[] actual = ArrayFilter.FilterDigit(source, filter);

            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test generation of ArgumentNullException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsNullArrayTest()
            => ArrayFilter.FilterDigit(null, 3);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IsDigitOutOfRangeTest()
        {
            int[] array = { 1, 2, 3 };

            ArrayFilter.FilterDigit(array, 10);
        }
    }
}

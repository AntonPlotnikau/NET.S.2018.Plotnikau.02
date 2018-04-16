using System;
using System.Collections.Generic;
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

            IEnumerable<int> actual = ArrayFilter.Filter(source, new DigitFilter(filter));

            int i = -1;
            foreach (int item in actual) 
            {
                Assert.AreEqual(expected[++i], item);
            }
        }

        /// <summary>
        /// Test generation of ArgumentNullException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsNullArrayTest()
            => ArrayFilter.Filter(null, new DigitFilter(3));

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IsDigitOutOfRangeTest()
        {
            int[] array = { 1, 2, 3 };

            ArrayFilter.Filter(array, new DigitFilter(10));
        }
    }
}

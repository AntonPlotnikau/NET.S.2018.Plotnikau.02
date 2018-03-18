using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberOperations;

namespace NumberOperationsTests
{
    [TestClass]
    public class MathNumberOperationsTests
    {

        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\InsertNumberTestsData.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        public void InsertNumberTest()
        {
            int numberSource = Convert.ToInt32(TestContext.DataRow["numberSource"]);
            int numberln = Convert.ToInt32(TestContext.DataRow["numberln"]);
            int firstBit = Convert.ToInt32(TestContext.DataRow["firstBit"]);
            int secondBit = Convert.ToInt32(TestContext.DataRow["secondBit"]);
            int expected = Convert.ToInt32(TestContext.DataRow["ExpectedResult"]);

            int actual = MathNumberOperations.InsertNumber(numberSource, numberln, firstBit, secondBit);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\InsertNumberException.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IsOutOfRangeException()
        {
            int numberSource = Convert.ToInt32(TestContext.DataRow["numberSource"]);
            int numberln = Convert.ToInt32(TestContext.DataRow["numberln"]);
            int firstBit = Convert.ToInt32(TestContext.DataRow["firstBit"]);
            int secondBit = Convert.ToInt32(TestContext.DataRow["secondBit"]);

            MathNumberOperations.InsertNumber(numberSource, numberln, firstBit, secondBit);
        }
    }
}

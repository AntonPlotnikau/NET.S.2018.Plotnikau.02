using System;
using NUnit.Framework;
using NumberOperations;

namespace NumberOperationsNUnitTests
{
    [TestFixture]
    class MathNumberOperationsNUnitTests
    {
        [Test]
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void FindNthRootTest(double number, int degree, double precision, double expected)
        {
            double actual = MathNumberOperations.FindNthRoot(number, degree, precision);

            if (Math.Abs(actual - expected) > precision) 
            {
                Assert.Fail();
            }
        }

        [Test]
        [TestCase(8, 15, -7, -5)]
        [TestCase(8, 15, -0.6, -0.1)]
        public void FindNthRoot_Degree_Precision_ArgumentOutOfRangeException(double number, int degree, double precision, double expected)
            => Assert.Throws<ArgumentOutOfRangeException>(() => MathNumberOperations.FindNthRoot(number, degree, precision));

        [Test]
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(-8, 15, 3, 8, ExpectedResult = -120)]
        [TestCase(8, -15, 0, 31, ExpectedResult = -15)]
        public int InsertNumberTest(int numberSource, int numberln, int firstBit, int secondBit)
            => MathNumberOperations.InsertNumber(numberSource, numberln, firstBit, secondBit);

        [Test]
        [TestCase(15, 15, 8, 3)]
        [TestCase(8, 15, -1, 0)]
        [TestCase(8, 15, 0, 32)]
        public void InsertNumberTest_firstBit_secondBit_ArgumentOutOfRangeException(int numberSource, int numberln, int firstBit, int secondBit)
            => Assert.Throws<ArgumentOutOfRangeException>(() => MathNumberOperations.InsertNumber(numberSource, numberln, firstBit, secondBit));

        [Test]
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int FindNextBiggerNumberTest(int number)
            => MathNumberOperations.FindNextBiggerNumber(number);

        [Test]
        [TestCase(int.MinValue)]
        [TestCase(0)]
        public void FindNextBiggerNumberTest_number_ArgumentOutOfRangeException(int number)
            => Assert.Throws<ArgumentOutOfRangeException>(() => MathNumberOperations.FindNextBiggerNumber(number));
    }
}

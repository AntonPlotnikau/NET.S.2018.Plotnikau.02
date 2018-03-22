using System;
using NumberOperations;
using NUnit.Framework;

namespace NumberOperationsNUnitTests
{
    [TestFixture]
    class NODTests
    {
        [Test]
        [TestCase(32, 12, ExpectedResult = 4)]
        [TestCase(-23, 105, ExpectedResult = 1)]
        [TestCase(1023, 927, ExpectedResult = 3)]
        [TestCase(0, 15, ExpectedResult = 15)]
        public int EuclidAlgorithmTests(int value1, int value2)
            => NOD.EuclidAlgorithm(value1, value2);

        [Test]
        [TestCase(32, 12, 24, ExpectedResult = 4)]
        [TestCase(-4, 8, 2, ExpectedResult = 2)]
        [TestCase(1023, 927, 33, ExpectedResult = 3)]
        [TestCase(0, 15, 30, ExpectedResult = 15)]
        public int EuclidAlgorithmTests(int value1, int value2, int value3)
            => NOD.EuclidAlgorithm(value1, value2, value3);

        [Test]
        [TestCase(32, 12, 24, 8, 44, 80, ExpectedResult = 4)]
        [TestCase(-4, 8, 2, -12, -28, 106, ExpectedResult = 2)]
        [TestCase(1023, 927, 33, 60, ExpectedResult = 3)]
        [TestCase(0, 15, 30, 225, ExpectedResult = 15)]
        public int EuclidAlgorithmTests(params int[] values)
            => NOD.EuclidAlgorithm(values);

        [Test]
        public void EuclidAlgorithmArgumentNullTests()
            => Assert.Throws<ArgumentNullException>(() => NOD.EuclidAlgorithm(null));

        [Test]
        [TestCase(-3)]
        public void EuclidAlgorithmArgumentOutOfRangeTests(int value)
            => Assert.Throws<ArgumentOutOfRangeException>(() => NOD.EuclidAlgorithm(value));

        [Test]
        [TestCase(32, 12, ExpectedResult = 4)]
        [TestCase(-23, 105, ExpectedResult = 1)]
        [TestCase(1023, 927, ExpectedResult = 3)]
        [TestCase(0, 15, ExpectedResult = 15)]
        public int SteinAlgorithmTests(int value1, int value2)
            => NOD.SteinAlgorithm(value1, value2);

        [Test]
        [TestCase(32, 12, 24, ExpectedResult = 4)]
        [TestCase(-4, 8, 2, ExpectedResult = 2)]
        [TestCase(1023, 927, 33, ExpectedResult = 3)]
        [TestCase(0, 15, 30, ExpectedResult = 15)]
        public int SteinAlgorithmTests(int value1, int value2, int value3)
            => NOD.SteinAlgorithm(value1, value2, value3);

        [Test]
        [TestCase(32, 12, 24, 8, 44, 80, ExpectedResult = 4)]
        [TestCase(-4, 8, 2, -12, -28, 106, ExpectedResult = 2)]
        [TestCase(1023, 927, 33, 60, ExpectedResult = 3)]
        [TestCase(0, 15, 30, 225, ExpectedResult = 15)]
        public int SteinAlgorithmTests(params int[] values)
            => NOD.SteinAlgorithm(values);

        [Test]
        public void SteinAlgorithmArgumentNullTests()
            => Assert.Throws<ArgumentNullException>(() => NOD.SteinAlgorithm(null));

        [Test]
        [TestCase(-3)]
        public void SteinAlgorithmArgumentOutOfRangeTests(int value)
            => Assert.Throws<ArgumentOutOfRangeException>(() => NOD.SteinAlgorithm(value));
    }
}

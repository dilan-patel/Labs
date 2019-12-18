using NUnit.Framework;
using Lab_008_TDD_Collections;

namespace Lab_009_RabbitTesting
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1, 2, 3, 4, 5, 280)]
        [TestCase(10, 11, 22, 21, 19, 280)]
        [TestCase(1, 4, 9, 16, 25, 1604)]
        [TestCase(10, 11, 12, 13, 14, 1405)]
        public void RabbitGrowthAfterThree(int a, int b, int c, int d, int e, int expected)
        {
            int actual = TestCollections.ArrayListDictionaryGetTotal(a, b, c, d, e);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(1, 2, 3, 4, 5, 280)]
        [TestCase(10, 11, 22, 21, 19, 280)]
        [TestCase(1, 4, 9, 16, 25, 1604)]
        [TestCase(10, 11, 12, 13, 14, 1405)]
        public void RabbitGrowthTest(int a, int b, int c, int d, int e, int expected)
        {
            int actual = TestCollections.ArrayListDictionaryGetTotal(a, b, c, d, e);
            Assert.AreEqual(expected, actual);
        }
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Lab_008_TDD_Collections;
using Lab_009_Rabbit_Tests;

namespace LAB_009_RabbitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }


        [TestCase(1, 2, 3, 4, 5, 280)]
        [TestCase(10, 11, 22, 21, 19, 280)]
        [TestCase(1, 4, 9, 16, 25, 1604)]
        [TestCase(10, 11, 12, 13, 14, 1405)]
        public void RabbitGrowthAfterThree(int a, int b, int c, int d, int e, int expected)
        {
            int actual = TestCollections.ArrayListDictionaryGetTotal(a, b, c, d, e);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 7, 8)]
        public void RabbitGrowthTests(int totalYears, int expectedRabbitAge, int expectedRabbitCount)
        {
            //Arrange
            //Act
            //Assert

            (int actualCumulativeAge, int actualRabbitCount) = RabbitCollection.MultiplyRabbits(totalYears);
            Assert.AreEqual(expectedRabbitAge, actualCumulativeAge);
            Assert.AreEqual(expectedRabbitCount, actualRabbitCount);
        }
    }
}

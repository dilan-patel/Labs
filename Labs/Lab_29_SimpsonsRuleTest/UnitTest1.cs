using NUnit.Framework;
using Lab_29_SimpsonsRule;

namespace Lab_29_SimpsonsRuleTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void TestSimpsonsRule(int expected)
        {
            int actual = Simpson.SimpsonRule();
            Assert.AreEqual(actual, expected);
        }
    }
}
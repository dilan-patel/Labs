using NUnit.Framework;
using Lab_17_NorthwindTests;
using LAB_014_LINQ;

namespace Lab_17_NwindTests
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

        [TestCase(null, -1)] // how many cust total?
        [TestCase("London", 5)]
        [TestCase("London", 1)]

        public void TestNumberOfNorthwindCustomers(string city, int expected)
        {
            //arrange
            //var testInstance = new LAB_014_LINQ.NorthwindCustomers();
            //act
            //var actual = testInstance.NumberOfNorthwindCustomers();
            //expected
           //Asert.AreEqual(expected, LAB_014_LINQ.Program.GetCustomers(city));
        }
    }
}
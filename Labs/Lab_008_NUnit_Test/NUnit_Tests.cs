using NUnit.Framework;
using Lab_008_TDD_Collections;
using Lab_009_Rabbit_Tests;

using Lab_020_NwindProducts;

namespace Lab_008_NUnit_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //[TestCase(1, 2, 3, 4, 5, 280)]
        //[Test]
        //public void TestGetTotal()
        //{
        //    ArrayListDictionary ald = new ArrayListDictionary();
        //    Assert.AreEqual(280, ald.GetTotal(1, 2, 3, 4, 5));
        //    Assert.AreEqual(280, 280);
        //}

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


        [TestCase(null,-1)] // how many cust total?
        [TestCase("London", -1)]

        public void TestNumOfNorthwindCustomers(string city, int expected)
        {
            //arrange
            //var testInstance = new NorthwindCustomers();
            //act
            //var actual = testInstance.NumberOfNorthwindCustomers();
            //expected
           //ssert.AreEqual(expected, LAB_014_Linq.Program.Get);
        }


        #region TestNumberOfProducts
        [TestCase("p", 3)]

        public void TestNumberOfProductsStartingWithP(string product, int expected)
        {
            //arrange - instance

            //act - method
            //var actual = 

            //assert
            Assert.AreEqual(expected, Lab_020_NwindProducts.NorthwindProducts.GetProducts(product));

        }
        #endregion

    }



}
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using Lab_28_Fibonacci;
using Lab_29_SimpsonsRule;

namespace Lab_28_FibonacciTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [TestCase(0, 0)]
        [TestCase(7, 13)]
        [TestCase(8, 21)]
        [TestCase(2, 1)]
        [TestCase(14, 377)]

        public void TestFibonacciSequence(int n, int expected)
        {

            int actual = Fibonacci.ReturnFibonacciNthItemInSequence(n);
            Assert.AreEqual(expected, actual);
        }


        //public void TestSimpsonsRule(int expected)
        //{
        //    //Simpson si = new Simpson();
        //    int actual = Simpson.SimpsonsRule();
        //    Assert.AreEqual(actual, expected);
        //}

        
    }

    
}

namespace Lab_29_SimpsonsRule
{


    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [TestCase(72)]
        public void TestSimpsonsRule(int expected)
        {
            //Simpson si = new Simpson();
            //int actual = si.SimpsonRule();
            //Assert.AreEqual(actual, expected);
        }

    }


}
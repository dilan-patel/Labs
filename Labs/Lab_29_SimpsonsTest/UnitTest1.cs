using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using Lab_29_SimpsonsRule;

namespace Lab_29_SimpsonsTest
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
            int actual = Simpson.SimpsonRule();
            Assert.AreEqual(actual, expected);
        }
    }
}
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using Lab_29_SimpsonsRule;

namespace Lab_29_SimpsonsRuleTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSimpsonsRule(int expected)
        {
            Simpson si = new Simpson();
            int actual = Simpson.SimpsonRule();
            Assert.AreEqual(actual, expected);
        }
    }
}
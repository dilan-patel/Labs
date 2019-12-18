using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab_009_Rabbit_Test
{
    [TestClass]
    public class UnitTest1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
        }

        public class RabbitCollection
        {

            public static List<Rabbit> rabbits = new List<Rabbit>();
            public List<Rabbit> MultiplyRabbits(int totalYears)
            {
                return rabbits;
            } 
        }

        public class Rabbit
        {
            public int RabbitId { get; set; }
            public string RabbitName { get; set; }
            public int RabbitAge { get; set; }
        }
    }
}

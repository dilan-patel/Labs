using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Lab_29_SimpsonsRule
{
    class Program
    {
        static void Main(string[] args)
        {
            //Simpson si = new Simpson();
            //si.SimpsonRule();
            //Console.WriteLine(si.SimpsonsRule());
        }


        public static class Simpson
        {
            //IEnumerable<int> xValues = Enumerable
            public static int SimpsonsRule()
            {
                //int[] xValues = new int[] { 0, 1, 2, 3, 4, 5, 6 };
                //int[] yValues = new int[] { 0, 1, 4, 9, 16, 25, 36 };

                int sumOfOdds = (1 + 9 + 25);
                int sumOfEvens = (4 + 16);
                int dx = ((6 - 0) / 6);

                int simpsons = (dx*(0 + (4 * sumOfOdds) + (2 * sumOfEvens) + 36))/3;


                return simpsons;
            }
        }

        /*
         * Homework!
         * Graph of Y=X*X (Can hard code)
         * Points 0,1,2,3,4,5,6 = N (Value of X)
         * Value of Y : 0,1,4,9,25,36
         * Goal : Approximate Area under graph
         * Area = ((MAX X - MIN X)/3N) * [Y(Zeroth item) + Y(Last item)
         * + 4 (Odd-Indexed items ie N = 1,3,5)
         * + 2 (Even-Indexed items ie N = 2,4)]
        */
    }
}

using System;

namespace Lab_28_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public static class Fibonacci
    {
        public static int ReturnFibonacciNthItemInSequence(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n < 3)
            {
                return 1;
            }
            else
            {
                return ReturnFibonacciNthItemInSequence(n - 1) + ReturnFibonacciNthItemInSequence(n - 2);
            }
        }
    }
}

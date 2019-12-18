using System;

namespace Lab_010_Events
{
    class Program
    {

        delegate void MyDelegate();

        static event MyDelegate MyEvent;

        static void Main(string[] args)
        {
            MyEvent += Method01;
            MyEvent += Method02;
        }

        static void Method01()
        {
            Console.WriteLine("Running Method01.");
        }

        static void Method02()
        {
            Console.WriteLine("Running Method02.");
        }
    }
}

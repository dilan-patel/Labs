using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LAB_15_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var task01 = new Task(
                () => { }
            );

            var task02 = new Task(
                () => { Console.WriteLine("In task 02"); }
            );

            task02.Start();

            var task03 = Task.Run(() => { Console.WriteLine("In task 03"); });
            var task04 = Task.Run(() => { Console.WriteLine("In task 04"); });
            var task05 = Task.Run(() => { Console.WriteLine("In task 05"); });

            
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.ReadLine();     
        }
    }
}

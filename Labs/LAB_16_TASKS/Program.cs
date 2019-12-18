using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;

namespace LAB_16_TASKS
{
    class Program
    {
        static Stopwatch s = new Stopwatch();
        static void Main(string[] args)
        {
            
            s.Start();

            var task01 = Task.Run(() => {
                Console.WriteLine("Task01 is running!");
                Console.WriteLine($"Task01 completed at time: {s.ElapsedMilliseconds}");
            });

            var actionDelegate = new Action(SpecialActionMethod); // Pass in method as argument
            var task02 = new Task(actionDelegate);
            task02.Start();

            

            Task[] taskArray = new Task[]
            {
                new Task( ()=>{ //do a job
                }),
                new Task( ()=>{ //do a job
                }),
                new Task( ()=>{ //do a job
                }),
                new Task( ()=>{ //do a job
                }),
                new Task( ()=>{ //do a job
                })
            };

            foreach(var task in taskArray)
            {
                task.Start();
            }

            // Named tasks
            var taskArray2 = new Task[3];
            taskArray2[0] = Task.Run(() => { 
                Thread.Sleep(100);
                Console.WriteLine($"Array Task 0 completed at {s.ElapsedMilliseconds}");
            });
            taskArray2[1] = Task.Run(() => {
                Thread.Sleep(50);
                Console.WriteLine($"Array Task 1 completed at {s.ElapsedMilliseconds}");
            });
            taskArray2[2] = Task.Run(() => {
                Thread.Sleep(10);
                Console.WriteLine($"Array Task 2 completed at {s.ElapsedMilliseconds}");
            });

            // Wait for one or all tasks in array to complete.
            Task.WaitAny(taskArray2);
            Console.WriteLine($"Waiting for first array task to compelete at {s.ElapsedMilliseconds}");
            // Wait for all
            Task.WaitAll(taskArray2);
            Console.WriteLine($"Waiting for all array tasks, completed at: {s.ElapsedMilliseconds}");


            // Parallel foreach loop

            int[] myCollection = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            // Regular foreach loop is in order: 1, 2, 3, 4...
            // Parallel foreach loop does x jobs at same time, waits for answers.

            Parallel.ForEach(myCollection, (item)=> {
                Thread.Sleep(item * 10);
                Console.WriteLine($"Foreach loop item {item} finishing at time {s.ElapsedMilliseconds}");
            });

            var t = s.ElapsedMilliseconds;
            Console.WriteLine($"Now run as sync loop and starting at time {s.ElapsedMilliseconds}");
            foreach(var item in myCollection)
            {
                Thread.Sleep(item * 100);
                Console.WriteLine($"Sync Foreach Loop item {item} finishing at time {s.ElapsedMilliseconds}");
            }

            var databaseOutput =
                (from item in myCollection
                 select item).AsParallel().ToList();



            //getting data back from tasks
            var TaskWithoutReturningData = new Task(()=> { });
            var TaskWithReturningData = new Task<int>(() =>
           {
               int total = 0;
               for (int i = 0; i < 100; i++)
               {
                   total += i;
               }
               return total;
           });

            TaskWithReturningData.Start();

            Console.WriteLine($"Counted to 100 using background task" +
                $"to hand main thread while it waits. The answer is {TaskWithReturningData.Result}");
            Console.WriteLine("Actually, waiting for result by definition turns it into a synchronous operation.");

            Console.WriteLine($"Application has finished at time {s.ElapsedMilliseconds}");
            //Console.WriteLine($"Application has finished at time {s.ElapsedTicks}");
            Console.ReadLine();

        }

        static void SpecialActionMethod()
        {
            Console.WriteLine("This action method takes no parameters and returns nothing, just performs an action. In this case, printing out.");
            Console.WriteLine($"SpecialActionMethod completed at time: {s.ElapsedMilliseconds}");

            var total = 0;
            for (int i = 0; i < 1_000; i++)
            {
                total += 1;
            }
            Console.WriteLine(total);
            Thread.Sleep(2000);
        }
    }
}

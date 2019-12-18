using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab_018_Streaming
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //system.io writing files
            File.WriteAllText("data.txt", "Hello this is some data.");

            //system.io writing from array
            var myArray = new string[] { "Hello", "this", "is", "some", "data", "from", "an", "array." };
            File.WriteAllLines("ArrayData.txt", myArray);

            Console.WriteLine(File.ReadAllText("data.txt"));

            for (int i = 0; i < 10; i++)
            {
                File.AppendAllText("data.txt", $"\nAdding line {i} at {DateTime.Now}");
            }

            Console.WriteLine(File.ReadAllText("data.txt"));

            var output = File.ReadAllLines("ArrayData.txt").ToList();
            output.ForEach(line => Console.WriteLine(line));

            Directory.CreateDirectory("Here is a folder");
            //File.Create("Here is a folder\\myfile.txt");
            //File.Create(@"Here is a folder \myfile2.txt");

            Directory.CreateDirectory(@"C:\RootFolder");
            Console.WriteLine(Directory.Exists(@"C:\RootFolder"));

            var numberOfLines = 1_000_000;
            var s = new Stopwatch();
            s.Start();

            using (var stream01 = new StreamWriter("output.dat"))
            {
                stream01.WriteLine($"Logging some data as {DateTime.Now}");
            }

            var writeTime = s.ElapsedMilliseconds;
            Console.WriteLine($"It took {s.ElapsedMilliseconds} to write {numberOfLines} lines");
            //read data

            string nextline;

            using (var reader = new StreamReader("output.dat"))
            {
                //reader does not know how big file is until reader.readline is null
                while (reader.ReadLine() != null)
                {
                    //Console.WriteLine(nextline);
                }
            }

            Console.WriteLine($"It took {s.ElapsedMilliseconds - writeTime} to write {numberOfLines} lines");

            //building a string
            //regular string building with a genereate a new instance every time
            s.Restart();

            var longString = "";

            using (var reader = new StreamReader("output.dat"))
            {
                while ((nextline = reader.ReadLine()) != null)
                {
                    longString += nextline;
                }
                reader.Close();
                Console.WriteLine($"It took {s.ElapsedMilliseconds - writeTime} to write {numberOfLines} lines");
            }

            longString = "";
            var stringBuilder = new StringBuilder();

            using (var reader = new StreamReader("output.dat"))
            {
                while ((nextline = reader.ReadLine()) != null)
                {
                    stringBuilder.Append(nextline);
                }
                reader.Close();
                Console.WriteLine($"It took {s.ElapsedMilliseconds} to add {numberOfLines} strings together using string builder");
            }
        }
    }
}
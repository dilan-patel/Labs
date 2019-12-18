using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_008_TDD_Collections
{


// TDD Lab Exercise : Collections
// Create a new project called Lab_08_TDD_Collections which is a Console app in .NET Core
// Add a class called Lab_08_Array_List_Dictionary
// Add a method int Lab_08_Array_List_Dictionary_Get_Total(int a, b, c, d, e)
// Create some code to take in 5 numbers as input
// Take those numbers, add 5, and put into an Array
// Iterate over the array, extract the numbers, square the numbers, and add to a List
// Iterate over the list, subtract 10, add to a Dictionary<int,int>
// Iterate over dictionary and return sum
// Return the answer

    class Program
    {
        static void Main(string[] args)
        {
            ArrayListDictionary ald = new ArrayListDictionary();
            //int result = ald.GetTotal(1, 2, 3, 4, 5);
            int result = TestCollections.ArrayListDictionaryGetTotal(10, 11, 12, 13, 14);
            Console.WriteLine("The result is: " + result);
        }
    }

    public class TestCollections
    {
        public static int ArrayListDictionaryGetTotal(int a, int b, int c, int d, int e)
        {
            ArrayListDictionary ald = new ArrayListDictionary();
            int result = ald.GetTotal(a, b, c, d, e);
            return result;
        }
    }

    class ArrayListDictionary
    {
        int[] array = new int[5];
        List<int> list = new List<int>();
        Dictionary<int, int> dictionary = new Dictionary<int, int>();

       public int GetTotal(int a, int b, int c, int d, int e)
        {
            int result = 0;

            array[0] = a + 5;
            array[1] = b + 5;
            array[2] = c + 5;
            array[3] = d + 5;
            array[4] = e + 5;

            for (int i = 0; i < 5; i++)
            {
                list.Add(array[i] = array[i] * array[i]);
                dictionary.Add(i + 1, list[i] - 10);
            }

            foreach (var item in dictionary)
            {
                result = dictionary.Sum(x => x.Value);
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Lab_22_Serialization;

namespace Lab_24_SerializeBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer1 = new Customer(1, "Billy", "BILID");
            var customer2 = new Customer(2, "Bob", "BOBID");
            var customer3 = new Customer(3, "Jeffrey", "JEFID");
            var customers = new List<Customer> { customer1, customer2, customer3 };


            // formatters : allow us to serialise to Binary
            var formatter = new BinaryFormatter();

            // stream to FILE
            using (var stream = new FileStream("data.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, customers);
            }

            // readback
            var BinaryString = File.ReadAllText("data.bin");

            // deserialise
        }


    }
}

using System;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Collections.Generic;

namespace Lab_22_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer1 = new Customer(1, "Billy", "BILID");
            var customer2 = new Customer(2, "Bob", "BOBID");
            var customers = new List<Customer> { customer1, customer2 };
            var formatter = new SoapFormatter();

            using (var stream = new FileStream("data.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, customers);
            }

            Console.WriteLine(File.ReadAllText("data.xml"));

            var customersFromXMLFile = new List<Customer>();

            using (var reader = File.OpenRead("data.xml"))
            {
                customersFromXMLFile = formatter.Deserialize(reader) as List<Customer>;
            }

            customersFromXMLFile.ForEach(c => Console.WriteLine(($"{c.CustomerID}{c.CustomerName}")));

        }
        
    }

    [Serializable]
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        [NonSerialized]
        private string NINO; //opt out

        public Customer(int id, string name, string nino)
        {
            this.CustomerID = id;
            this.CustomerName = name;
            this.NINO = nino;
        }
    }
}

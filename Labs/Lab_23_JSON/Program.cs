using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace Lab_23_JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer1 = new Customer(1, "Billy", "BILID");
            var customer2 = new Customer(2, "Bob", "BOBID");
            var customer3 = new Customer(3, "Jeffrey", "JEFID");
            var customers = new List<Customer> { customer1, customer2, customer3};


            //serialise
            var JSONCustomerList = JsonConvert.SerializeObject(customers);

            //peek at this object
            Console.WriteLine(JSONCustomerList);

            //stream to file
            File.WriteAllText("data.json", JSONCustomerList);

            //read
            var JSONstring = File.ReadAllText("data.json");

            //deserialize
            var customersFromJSON = JsonConvert.DeserializeObject<List<Customer>>(JSONstring);


            //print
            customersFromJSON.ForEach(c => Console.WriteLine($"{c.CustomerID}, {c.CustomerName}"));
        }
    }


    class Customer
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

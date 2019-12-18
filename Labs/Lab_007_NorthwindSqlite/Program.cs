using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_007_NorthwindSqlite
{
    internal class Program
    {
        //1. Create a list for the table.
        public static List<Customer> customers = new List<Customer>();

        private static void Main(string[] args)
        {
            PrintCustomers();
        }

        private static void PrintCustomers()
        {
            using (var db = new NorthwindDbContext())
            {
                customers = db.Customers.ToList();
            }
            customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-10}{c.ContactName,-30}{c.CompanyName,-20}"));
        }
    }

    // Connect to database.
    internal class NorthwindDbContext : DbContext
    {
        // Set table to match table in database.
        public DbSet<Customer> Customers { get; set; }

        // Method to connect to database.

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connectionString = @"Data Source = C:\Users\Dilan Patel\Engineering45\SQLite\Northwind.db";
            builder.UseSqlite(connectionString);
        }
    }

    internal class Customer
    {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
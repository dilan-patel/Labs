using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using System.Collections.Generic;
using System.Linq;

namespace LAB_014_LINQ
{
    internal class Program
    {
        #region Explanation
        /*
         * 1. Read Northwind using Entity Core 2.1.1.
         * 2. Basic LINQ
         * 3. Advanced LINQ (Lambda)
         */
        #endregion Explanation

        private static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            List<ModifiedCustomer> modifiedcustomers = new List<ModifiedCustomer>();
            List<Product> products = new List<Product>();
            List<Category> categories = new List<Category>();

            using (var db = new Northwind())
            {
                customers = db.Customers.ToList();

                // Simple linq from local collection
                // Whole dataset is returned, more data
                // IEnumerable Array
                var selectedCustomers =
                from customer in customers
                select customer;

                // Same query over database directly
                // Only return data we need
                // Lazy loading - Query is not actually executed
                // Data has not actualy arrived yet
                var selectedCustomers2 =
                    (from customer in db.Customers
                     where customer.City == "London" || customer.City == "Berlin"
                     orderby customer.ContactName
                     select customer).ToList();
                printCustomer(selectedCustomers2);
                
                // force data by pushing to a list, i.e ToList() or by taking aggregate e.g. Sum, Count

                var selectedCustomers3 =
                (from customer in db.Customers
                 select new
                 {
                     Name = customer.ContactName,
                     Location = customer.City + " " + customer.Country
                 }).ToList();

                foreach (var c in selectedCustomers3)
                {
                    Console.WriteLine("SelectedCustomers3");
                    Console.WriteLine($"{c.Name,-20}{c.Location}");
                    Console.WriteLine("");
                }


                var selectedCustomers4 =
                    (from c in db.Customers
                     select new
                     ModifiedCustomer(c.ContactName, c.City + " " + c.Country)).ToList();

                var selectedCustomers5 = 
                    from cust in db.Customers
                    group cust by cust.City into Cities
                    orderby Cities.Count() descending
                    select new
                    {
                        City = Cities.Key,
                        Count = Cities.Count()
                    };

                foreach(var c in selectedCustomers5.ToList())
                {
                    Console.WriteLine("SelectedCustomers5");
                    Console.WriteLine($"{c.City,-15}{c.Count}");
                    Console.WriteLine("");
                }



                var listofproducts =
                    (from p in db.Products
                     join c in db.Categories
                     on p.CategoryID equals c.CategoryID
                     select new
                    {
                        ID = p.ProductID,
                        Name = p.ProductID,
                        Category = c.CategoryName
                    }).ToList();
                listofproducts.ForEach(p =>
                Console.WriteLine($"{p.ID,15}{p.Name,-30}{p.Category}"));

                Console.WriteLine("\n\nNow print same list but using smarter join tables with . Notation");

                products = db.Products.ToList();
                categories = db.Categories.ToList();
                products.ForEach(p =>
                Console.WriteLine($"{p.ProductID,-15}{p.ProductName}{p.Category.CategoryName}"));



                //secet distinct

                Console.WriteLine(("\n\n List of cities distinct \n"));
                var cityList = db.Customers.Select(c => c.City).ToList();

            }




            


            

        }

        public static int GetCustomers(string city)
        {
            using(var db = new Northwind())
            {
                if (string.IsNullOrEmpty(city))
                {
                    return db.Customers.Count();
                }
                else
                {
                    return db.Customers.Where(c => c.City == city).Count();
                }
            }
        }

        static void printCustomer(List<Customer> customers)
        {
            customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-10}" + $"{c.ContactName,-30}{c.CompanyName,-40}{c.City}"));
        }
    }





    #region DatabaseContextAndClasses

    // connect to database

    
    public partial class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }

    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            this.Products = new List<Product>();
        }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public short? UnitsInStock { get; set; } = 0;
        public short? UnitsOnOrder { get; set; } = 0;
        public short? ReorderLevel { get; set; } = 0;
        public bool Discontinued { get; set; } = false;
    }

    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security = true;" + "MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            // define a one-to-many relationship
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);

            modelBuilder.Entity<Product>()
                .Property(c => c.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products);

        }
        
        
    }

    public class ModifiedCustomer
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public ModifiedCustomer(string Name, string Location)
        {
            this.Name = Name;
            this.Location = Location;
        }
    }

    #endregion DatabaseContextAndClasses
}
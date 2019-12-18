using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;

namespace Lab_17_NorthwindTests
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class NorthwindCustomers
        {
            public int NumberOfNorthwindCustomers(string city)
            {
                using (var db = new NorthwindEntities())
                {
                    if(city == null || city == "")
                    {
                        return db.Customers.Count();
                    }
                    else
                    {
                        return db.Customers.Where(c => c.City == city).Count();
                    }
                }
            }
        }
    }
}

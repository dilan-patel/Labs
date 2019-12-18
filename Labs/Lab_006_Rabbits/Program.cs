using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Collections.Generic;
using System.Linq;

namespace Lab_006_Rabbits
{
    class Program
    {
        public static List<Rabbit> rabbits = new List<Rabbit>();
        static void Main(string[] args)
        {

            var rabbit = new Rabbit("Ruth", 1);
            var rabbit2 = new Rabbit("Vanessa", 2);


            AddRabbit(rabbit);
            AddRabbit(rabbit2);
            ListRabbits();

            UpdateRabbit();
            ListRabbits();
        }

        static void ListRabbits()
        {
            using (var db = new RabbitDbContext())
            {
                rabbits = db.Rabbits.ToList();
            }
            rabbits.ForEach(r => Console.WriteLine($"{r.RabbitId,-10}{r.RabbitName,-20}{r.RabbitAge}"));
        }

        static void AddRabbit(Rabbit r)
        {
            using (var db = new RabbitDbContext())
            {
                db.Rabbits.Add(r);
                db.SaveChanges();
            }
        }


        static void UpdateRabbit()
        {
            using (var db = new RabbitDbContext())
            {
                var rabbitToUpdate = db.Rabbits.Find(1);
                rabbitToUpdate.RabbitName = "Molly";
                db.SaveChanges();
            }
        }

        static void PrintRabbits()
        {
            foreach (Rabbit item in rabbits)
            {
                Console.WriteLine(rabbits);
            }
        }
    }

    // Connect to database.
    class RabbitDbContext : DbContext
    {
        // Set table in database called 'Rabbits'.
        public DbSet<Rabbit> Rabbits { get; set; }

        // Method to connect to database.

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=RabbitsDB;";
            builder.UseSqlServer(connectionString);
        }
    }
}

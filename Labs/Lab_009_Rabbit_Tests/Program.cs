using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab_009_Rabbit_Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public static class RabbitCollection
    {
        public static List<Rabbit> rabbits = new List<Rabbit>();
        public static (int cumulativeRabbitAge, int rabbitCount) MultiplyRabbits(int totalYears)
        {

            var rabbit0 = new Rabbit
            {
                RabbitId = 0, 
                RabbitName = "Rabbit0", 
                RabbitAge = 0
            };

            //for (int year = 0; year < totalYears; year++)
            //{
            //    foreach(var rabbit in rabbits.ToArray())
            //    {
            //        var newRabbit = new Rabbit();
            //        rabbits.Add(newRabbit);
            //        rabbits.CumulativeRabbitAge++;
            //    }
            //}

            int cumulativeRabbitAge = 0;
            rabbits.ForEach(r => cumulativeRabbitAge += r.RabbitAge);

            return (cumulativeRabbitAge, rabbits.Count);
        }
    }

    public class Rabbit
    {
        public int RabbitId { get; set; }
        public string RabbitName { get; set; }
        public int RabbitAge { get; set; }

        public Rabbit()
        {
            this.RabbitId = RabbitCollection.rabbits.Count + 1;
            RabbitName = "Rabbit" + this.RabbitId;
            RabbitAge = 0;
        }
    }


}

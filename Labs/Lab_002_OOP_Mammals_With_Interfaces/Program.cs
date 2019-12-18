using System;

namespace Lab_002_OOP_Mammals_With_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {

            Lion lion1 = new Lion();
            lion1.Roar();
            lion1.SeeMyPrey();
            lion1.SmellMyPrey();

            Console.WriteLine("");

            Tiger tiger1 = new Tiger();
            tiger1.Roar();
            tiger1.SeeMyPrey();
            tiger1.SmellMyPrey();
        }
    }
}

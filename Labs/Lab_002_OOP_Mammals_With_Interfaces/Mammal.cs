using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_002_OOP_Mammals_With_Interfaces
{
    class Mammal
    {
        bool isWarmBlooded = true;
        double weight;
        double height;
        double length;

        public double Weight { get => weight; set => weight = value; }
        public double Height { get => height; set => height = value; }
        public double Length { get => length; set => length = value; }
        public bool IsWarmBlooded { get => isWarmBlooded; set => isWarmBlooded = value; }
    }

    class Cat : Mammal, IUseVision, IUseSmell
    {
        public virtual void Roar()
        {
            Console.WriteLine("Roar!");
        }
        public virtual void SeeMyPrey()
        {

        }
        public virtual void SmellMyPrey()
        {

        }
    }

    class Lion : Cat
    {
        public Lion()
        {
        }

        public override void Roar()
        {
            Console.WriteLine("Lion is roaring!");
        }

        public override void SeeMyPrey()
        {
            Console.WriteLine("Lion sees its prey.");
        }

        public override void SmellMyPrey()
        {
            Console.WriteLine("Lion smells its prey.");
        }
    }

    class Tiger : Cat 
    {
        public Tiger()
        {
        }

        public override void Roar()
        {
            Console.WriteLine("Tiger is roaring!");
        }

        public override void SeeMyPrey()
        {
            Console.WriteLine("Tiger sees its prey.");
        }

        public override void SmellMyPrey()
        {
            Console.WriteLine("Tiger smells its prey.");
        }
    }


    // Make the method in the interface, write the code body for method in class.

    public interface IUseVision
    {
        public void SeeMyPrey()
        {
        }
    }

    public interface IUseSmell
    {
        public void SmellMyPrey()
        {
        }
    }
}

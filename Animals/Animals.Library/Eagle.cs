using System;

namespace Animals.Library
{
    public class Eagle : ABird
    {
        public override string Name { get ; set; }

        public override void MakeSound()
        {
            Console.WriteLine("Caw Caw");
        }

        public void fly(string location)
        {
            Console.WriteLine($"{Name} flies to {location}");
        }

    }
}
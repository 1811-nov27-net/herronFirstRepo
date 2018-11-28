using System;
namespace Animals.Library
{
    public abstract class ABird : IAnimal
    {
        // abstract class cannot be instantiated but can provide implimentation to be shared by sub-classes
        public abstract string Name{ get; set; }
        public void GoTo(string location)
        {
            Console.WriteLine($"Flying to {location}");
        }
        public abstract void MakeSound();
    }
}
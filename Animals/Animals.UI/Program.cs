using System;
using Animals.Library;

namespace Animals.UI
{
    class Program
    {
        // this is required to start. Program.cs and Proram class name are conventions
        // static void Main(string[] args) is required

        // naming convention in C# PascalCase aka TitleCase for
        //      classes, methods, properties, namespaces
        // camelCase for local variables

        static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Bark();

            // using fields and properties

            dog.SetWeight(6);
            Console.WriteLine(dog.GetWeight());

            dog.Name = "Fido";
            Console.WriteLine(dog.Name);

            dog.Breed = "Golden retriever";

            dog.GoTo("the Park");

            Console.WriteLine("Hello World!");


            IAnimal animal = new Dog();
            animal = new Eagle();

            // not allowed to do specific things
            // animal.Fly(); error

            Eagle e = (Eagle) animal;
        }
        public void DisplayData(ABird bird)
        {
            Console.WriteLine(bird.Name);
        }
    }
}

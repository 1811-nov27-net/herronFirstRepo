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


            Console.WriteLine("Hello World!");
        }
    }
}

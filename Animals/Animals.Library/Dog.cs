using System;

namespace Animals.Library
{
    public class Dog : IAnimal
    {
        // fields - properties

        public int id { get; set; }

        // pathological example
        public string Name
        { 
            get{ return "Bob";} 
            set{ Console.WriteLine("Inside property setter");} 
        }

        private string _breed;
        public string Breed
        { 
            get {return _breed;}
            set
            {
                if (value != null && value != "")
                {
                    _breed = value;

                }

            } 
        }


        // property (with explitic backing field)
        private int _age;

        public int Age{
            get
            {
                return _age;

            }
            set
            {
                _age = value;
                // keyword "value" in a setter takes in assigned value

            }
        }

        private int Weight;
        // classic getters and setters
        public int GetWeight()
        {
            return Weight;
        }
        
        public void SetWeight(int weight)
        {
            Weight = weight;
        }
        // properties

        public void Bark()
        {
            Console.WriteLine("Woof");
        }

        public void MakeSound()
        {
            Bark();
        }

        public void GoTo(string location)
        {
            // string interpolation syntax
            string output = $"Walking to {location.ToLower()}.";
            Console.WriteLine(output);
        }
    }
}

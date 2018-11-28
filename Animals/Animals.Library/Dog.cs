using System;

namespace Animals.Library
{
    public class Dog
    {
        // fields - properties
        public string Name{ get; set; }
        public string Breed{ get; set; }


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

    }
}

using System;
using System.Collections.Generic;

namespace ArraysPlay
{
    class Program
    {
        static void Main(string[] args)
        {
            Arrays();
        }

        static void Arrays()
        {
            int[] intArray = new int[10];
            /*
             * default null for objects, 0 for ints, false for bool
            */
            Console.WriteLine(intArray[5]);

            for (int i = 0; i < intArray.Length; i++)
            {
                Console.Write(intArray[i]);

            }

            foreach (int item in intArray)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            /*
             * can use foreach with anything that implements IEnumerable interface. (Also used with LINQ)
             * 
             */

            int[,] trueMultiDArray = new int[5, 5];

            trueMultiDArray[3, 4] = 5;

            int[] array = new int[]
            {
                4, 8, 3, 2, 1, 2
            };
        }

        static void Lists()
        {
            var list = new List<bool>
            {
                true,
                true,
                false
            };

            var list2 = new List<bool>() { false, false, false };

            list2.AddRange(list);


        }

        static void sets()
        {
            var set = new HashSet<string>
            {

                // sets have no particular order to them.
                // do not allow duplicates

                "abc",
                "abc", // does nothing
                "def"
            };
            string conCats = "abc" + "def";
        }

        static void Dictionaries()
        {
            var dict = new Dictionary<string, string>
            {
                { "Germany", "Berlin" },
                { "USA", "Washington, DC" }
            };

            Console.WriteLine(dict["USA"]);
            dict["Mexico"] = "Mexico City";
        }
    }
}

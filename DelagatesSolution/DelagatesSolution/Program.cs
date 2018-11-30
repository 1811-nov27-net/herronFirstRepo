using System;
using System.Collections.Generic;
using System.Linq;

namespace DelagatesSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new MoviePlayer
            {
                CurrentMovie = "Lord of the Rings: The Fellowship of the Ring Extended Edition"
            };

            player.MovieFinished += EjectDisc;
            // player.MovieFinished -= EjectDisc;


            // Func is for non-Void return
            // Action is for Void return
            // Action<string> handler2 = EjectDisc;

            // player.MovieFinished += handler2;

            player.MovieFinished += s => Console.WriteLine($"lambda subscribe {s}");

            player.PlayMovie();
            // some Funcy Action Examples

            bool func(int n, string s) => true;
            // last type is return, others are arguments

            void func2(int num, string str, bool b)
            {
                if (b)
                {
                    Console.WriteLine(num);
                    Console.WriteLine(str);
                }
            }

        }
        static void EjectDisc()
        {
            Console.WriteLine("Ejecting disc.");
        }

        static void EjectDisc(string title)
        {
            Console.WriteLine($"Ejecting disc {title}.");
        }

        static void Linq()
        {
            var x = new List<string>();
            int longestLength = x.Max(s => s.Length);

            var ListOfFirstCharacters = x.Select(s => s[0]);

            // All (expects a bool-returning lambda - checks that all elements meet a condition)
            bool allShorterThan5Chars = x.All(s => s.Length < 5);
            // Where (filters the sequence for only elements that return true)
            var onlyTheLongElements = x.Where(s => s.Length > 20);

            bool b = x.Where(s => s.Length > 20).Select(s => s[0]).All(c => c == 'a' || c == 'b');
            List<char> listOfChars = ListOfFirstCharacters.ToList();
            // -ToList actually runs the search
            // all IEnumerable can do is get put in foreach loops
            // and have LINQ methods called on it.
        }

        static void Finally()
        {
            try
            {
                Console.WriteLine("try");


            }
            catch (ArgumentException e)
            {
                // matching exception
            }
            finally
            {
                // always runs. Even if uncaught exception in try block.
                // close resources here if you open them in the try
            }
        }
    }
}

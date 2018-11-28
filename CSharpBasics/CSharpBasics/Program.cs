using System;
using System.Collections.Generic;

namespace CSharpBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // local variables and types
            int x = 0;
            double y = 4.58; // 64-bit float
            decimal z = 5.001m; //128 bit

            string s = "string";
            bool b = true;
            b = false;

            // base class of enverything - object
            object o = true;
            o = 2;

            // var (compiler type inference)

            var xyz = "Hello";
            var b1 = true;
            //xyz = false; // error; no dynamic typing

            // use var when obvious; not when obscures useful context

            // control structures
            // loops

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            while (false)
            {
                // loop
            }

            do
            {
                // loop
            } while (false);

            if (true)
            {
                // do the thing
            }
            else
            {
                // Don't do the thing'
            }

            List<string> list = new List<string>();
            list.Add("asdf");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            // object-oriented
            //  have objects that associate data and behavior
            //  to represent "real" nouns
            //  create objects from templates called classes
            //  which define a contract at runtime

            // .NET framework

            // static typed
            // unified type system
            //   "primitives" (types with value semantics instead of reference semantics)
            //   *also* inherit from object.

            // garbage-collection
            // "managed" language (memory is managed for you)

            // functions are not quite first-class but in practice more or less
            // c sharp is somewhat functional, esp in practice with LINQ
            // (Language Integrated Query Language)


            // asynchronous programming support with TPL

            // exception handling


        }
    }
}

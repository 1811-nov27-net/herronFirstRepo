using System;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exceptions are runtime errors that might be handled
            // they are objects, and defined by objects... but they are "special"

            try
            {
                BadCode();

                // now never runs; BadCode
                var x = 4;
                var y = x / 0;
                Console.WriteLine("Can't see me, I'm the gingerbread man");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("divided by zero, moving on");
            }
            catch(InvalidCastException e)
            {
                Console.WriteLine("Handled Bad Cast");
            }

            

            Console.WriteLine("the saga continues");
        }

        static void BadCode()
        {
            try
            {
                object o = true;
                string s = (string)o;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Don't divide by zero");

            }
        }
    }
}

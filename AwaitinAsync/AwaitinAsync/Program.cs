using System;
using System.Threading;
using System.Threading.Tasks;

namespace AwaitinAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Dooma();
            Thread.Sleep(10000);

        }

        static async Task<int> Dooma()
        {
            await Doomb();
            Console.WriteLine("1");
            return 1;
        }

        static async Task<int> Doomb()
        {
            Console.WriteLine("2");
            await Task.Delay(1000);
            Doomc();
            return 2;
        }

        static async Task<int> Doomc()
        {
            await Task.Delay(5000);
            Console.WriteLine("3");
            return 3;
        }

        static async Task<int> Delay(int amount)
        {
            await Task.Delay(amount);
            return amount;

        }
    }
}

using System;
using System.Linq;

namespace _5.SumEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int arr = Console.ReadLine().
                Split(' ')
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .Sum();

            Console.WriteLine(arr);

        }
    }
}

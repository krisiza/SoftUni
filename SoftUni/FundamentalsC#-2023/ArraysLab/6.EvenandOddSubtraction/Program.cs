using System;
using System.Linq;

namespace _6.EvenandOddSubtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sumEven = 0, sumOdd = 0;

            int[]arr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            for(int i = 0; i < arr.Length; i++) 
            {
                if (arr[i] % 2 == 0)
                    sumEven += arr[i];
                else
                    sumOdd += arr[i];
            }

            int diff = sumEven - sumOdd;
            Console.WriteLine(diff);
        }
    }
}

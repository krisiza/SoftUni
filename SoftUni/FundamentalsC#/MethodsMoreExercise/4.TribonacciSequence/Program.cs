using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.TribonacciSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            GetFibonacciSequence(n);
        }
        static void GetFibonacciSequence(int n)
        {
            List<int> fibons = new List<int>();
            int sum = 0;
            fibons.Add(1);
            for (int i = 1; i < n; i++)
            {
                sum = 0;
                for (int j = fibons.Count - 1; j >= fibons.Count - 3; j--)
                {
                    if (j < 0)
                        break;
                    sum += fibons[j];
                }
                fibons.Add(sum);
            }
            Console.WriteLine(String.Join(" ", fibons));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumAdjacentEqualNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();

            for(int i = 0; i < numbers.Count-1; i++) 
            {
                double sum = 0;
                if (numbers[i] == numbers[i + 1])
                {
                    sum += numbers[i] + numbers[i + 1];
                    numbers.Remove(numbers[i + 1]);
                    numbers.Remove(numbers[i]);
                    numbers.Insert(i, sum);

                    i = -1;
                }
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}

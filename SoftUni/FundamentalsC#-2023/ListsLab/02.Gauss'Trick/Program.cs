using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Gauss_Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            bool even = false;

            if (list.Count % 2 == 0)
                even = true;

            int middIndex = list.Count / 2;
            int endIndex = list.Count-1;
            List<int> result = new List<int>();

            for (int i = 0; i < middIndex; i++)
            {
                result.Add(list[i] + list[endIndex]);
                endIndex--;
            }

            if (!even)
                result.Add(list[middIndex]);

            Console.WriteLine(String.Join(" ", result));
        }
    }
}

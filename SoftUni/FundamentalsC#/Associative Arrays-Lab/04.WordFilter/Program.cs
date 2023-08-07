using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.WordFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                .Split()
                .Where(x => x.Length % 2 == 0)
                .ToArray();


            foreach (string s in arr) 
            {
                Console.WriteLine(s);
            }
        }
    }
}

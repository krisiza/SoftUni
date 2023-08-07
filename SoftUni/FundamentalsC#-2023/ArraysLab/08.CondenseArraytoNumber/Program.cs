using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CondenseArraytoNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            for(int i = 0; i < arr.Length; i++) 
            {
                for(int j = 0; j < arr.Length - 1 - i; j++)
                {
                    arr[j] = arr[j] + arr[j + 1];
                }
            }

            Console.WriteLine(arr[0]);

        }
    }
}

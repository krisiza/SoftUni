using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _07.AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split('|').ToList();
            List<string> apArr = new List<string>();
            List<string> numbersAr = new List<string>();

            for (int i = 0; i < numbers.Count; i++)
            {
                apArr = numbers[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

                for(int j = apArr.Count-1; j >= 0; j--) 
                {
                    numbersAr.Insert(0, apArr[j]);
                }
            }

            Console.WriteLine(String.Join(" ", numbersAr));

        }
    }
}

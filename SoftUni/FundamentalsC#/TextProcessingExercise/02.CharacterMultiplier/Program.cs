using System;
using System.Linq;
using System.Reflection;

namespace _02.CharacterMultiplier
{
    internal class Program
    {// 5680 + 10201 + 12876 + 11514 + 11742 + 101
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();

            int index = 0;

            if (arr[0].Length == arr[1].Length)
                index = SumIndex(arr, index);
            else if (arr[0].Length > arr[1].Length)         
                index = SumRest(arr[1], arr[0], index);
            else
                index = SumRest(arr[0], arr[1], index);

            Console.WriteLine(index);
        }
        static int SumIndex(string[] arr, int index)
        {
            for (int i = 0; i < arr[0].Length; i++)
            {
                index += arr[0][i] * arr[1][i];
            }
            return index;
        }
        static int SumShorter(string shorter, string longer, int index)
        {
            for (int i = 0; i < shorter.Length; i++)
            {
                index += shorter[i] * longer[i];
            }
            return index;
        }
        static int SumRest(string shorter, string longer, int index)
        {
            index += SumShorter(shorter, longer, index);

            for (int i = shorter.Length; i < longer.Length; i++)
            {
                index += longer[i];
            }
            return index;
        }
    }
}

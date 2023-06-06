using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _04.MixedupLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> mixesList = new List<int>();

            for (int i = 0, j = secondList.Count - 1; i < firstList.Count && j >= 0; i++, j--)
            {
                mixesList.Add(firstList[i]);
                mixesList.Add(secondList[j]);
            }

            List<int> remainingElements = new List<int>();

            if (firstList.Count > secondList.Count)
            {
                for (int i = firstList.Count - 2; i < firstList.Count; i++)
                {
                    remainingElements.Add(firstList[i]);
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    remainingElements.Add(secondList[i]);
                }
            }

            List<int> orderedList = new List<int>();
            for (int i = 0; i < mixesList.Count; i++)
            {
                if (mixesList[i] > Math.Min(remainingElements[0], remainingElements[1])
                    && mixesList[i] < Math.Max(remainingElements[0], remainingElements[1]))
                    orderedList.Add(mixesList[i]);
            }

            orderedList.Sort();
            Console.WriteLine(string.Join(" ", orderedList));
        }
    }
}

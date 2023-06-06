using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> list2 = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> result = new List<int>();
            bool list1Done = false;
            int indexEndList2 = 0;

            for (int i = 0; i < list1.Count; i++)
            {
                result.Add(list1[i]);

                if(indexEndList2 < list2.Count)
                {
                    result.Add(list2[indexEndList2]);
                    indexEndList2++;
                }

                if (list1.Count != list2.Count)
                {
                    if (i == list1.Count - 1)
                        list1Done = true;
                }

            }

            if (list1Done)
            {
                for (int i = indexEndList2; i < list2.Count; i++)
                {
                    result.Add(list2[i]);
                }
            }

            Console.WriteLine(String.Join(" ", result));
        }
    }
}

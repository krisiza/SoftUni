using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.AnonymousThreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> commad = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (commad[0] != "3:1")
            {
                string operation = commad[0];
                int firstIndex = int.Parse(commad[1]);
                int secondIndex = int.Parse(commad[2]);

                if (operation == "merge")
                    list = Merge(list, firstIndex, secondIndex);
                else if (operation == "divide")
                    list = Divide(list, firstIndex, secondIndex);

                commad = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            Console.WriteLine(String.Join(" ", list));
        }
        static List<string> Merge(List<string> list, int startInxex, int endIndex)
        {
            List<string> mergedList = new List<string>();
            string word = string.Empty;

            if (startInxex < 0 || startInxex > list.Count - 1)
                startInxex = 0;
            if (endIndex > list.Count - 1)
                endIndex = list.Count - 1;

            int counter = 0;
            for (int i = startInxex; i <= endIndex; i++)
            {
                word += list[startInxex + counter];
                counter++;
            }
            mergedList.Add(word);

            for (int i = endIndex + 1; i < list.Count; i++)
            {
                mergedList.Add(list[i]);
            }

            for (int i = startInxex - 1; i >= 0; i--)
            {
                mergedList.Insert(0, list[i]);
            }
            //Console.WriteLine(String.Join(" ", mergedList));
            return mergedList;
        }
        static List<string> Divide(List<string> list, int index, int partitions)
        {
            List<string> mergedList = new List<string>();
            string word = string.Empty;
            int count = 0;
            int wordLenth = list[index].Length / partitions;
            int wordsCounter = 1;

            for (int i = 0; i < list[index].Length;i++)
            {
                word+= list[index][i];
                count++;

                if(count == wordLenth)
                {
                    mergedList.Add(word);
                    wordsCounter++;
                    word= string.Empty;
                    count= 0;
                }
                if (wordsCounter == partitions)
                {
                    for (int j = i+1; j < list[index].Length; j++)
                    {
                        word+= list[index][j];
                        i = list[index].Length-1;
                    }
                }
            }

            if(word.Length > 0)
                mergedList.Add(word);


            for (int i = index+1; i < list.Count; i++)
            {
                mergedList.Add(list[i]);
            }

            for (int i = index - 1; i >= 0; i--)
            {
                mergedList.Insert(0, list[i]);
            }

            //Console.WriteLine(String.Join(" ", mergedList));
            return mergedList;
        }
    }
}

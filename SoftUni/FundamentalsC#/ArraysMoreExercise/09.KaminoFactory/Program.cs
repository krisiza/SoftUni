using System;
using System.Linq;

namespace К2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int[] bestDNA = new int[length];

            string input = Console.ReadLine();

            int counterOfOne = 0;
            int maxCounterOfOne = 0;
            int indexOfOne = 0;
            int sumArr = 0;
            int sumBest = 0;
            int counter = 0;
            int bestCounter = 0;

            while (input != "Clone them!")
            {
                counter++;
                int[] arr = input.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                sumArr = arr.Sum();

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == 1)
                    {
                        counterOfOne++;

                        if (maxCounterOfOne < counterOfOne ||
                            maxCounterOfOne == counterOfOne && indexOfOne > i ||
                            maxCounterOfOne == counterOfOne && i == indexOfOne && sumArr > sumBest)
                        {
                            maxCounterOfOne = counterOfOne;
                            indexOfOne = i;
                            bestDNA = arr;
                            sumBest = sumArr;
                            bestCounter = counter;
                        }
                    }
                    else
                        counterOfOne = 0;

                }
                sumArr = 0;
                counterOfOne = 0;

                input = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestCounter} with sum: {sumBest}.\n{string.Join(" ", bestDNA)}");
        }
    }
}


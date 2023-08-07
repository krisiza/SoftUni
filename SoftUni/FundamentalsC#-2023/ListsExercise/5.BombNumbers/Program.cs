using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> bombPow = Console.ReadLine().Split().Select(int.Parse).ToList();
            int bomb = bombPow[0];
            int power = bombPow[1];

            int indexBomb = 0;
            for (int j = 0; j < list.Count; j++)
            {
                int count = 1;
                if (list[j] == bomb)
                {
                    indexBomb = j;

                    for (int i = 0; i < power; i++)
                    {
                        if (indexBomb + 1 < list.Count)
                            list.RemoveAt(indexBomb + 1);
                        else
                            break;
                    }
                    for (int i = 0; i < power; i++)
                    {
                        if (indexBomb - count >= 0)
                            list.RemoveAt(indexBomb-count);
                        else
                            break;

                        count++;
                    }
                    list.RemoveAt(indexBomb - count + 1);

                    j = -1;
                }
            }

            Console.WriteLine(list.Sum());
        }
    }
}

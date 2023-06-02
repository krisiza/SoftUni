using System;

namespace _04.Sumof_TwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            bool found = false;
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                for (int y = start; y <= end; y++)
                {
                    counter++;
                    if (i + y == magicNum)
                    {
                        Console.WriteLine($"Combination N:{counter} ({i} + {y} = {magicNum})");
                        found = true;
                        if (found)
                            break;
                    }
                }
                if (found) break;
            }
            if (!found)
                Console.WriteLine($"{counter} combinations - neither equals {magicNum}");
        }
    }
}

using System;

namespace _09.SumofTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());

            int sum = 0;
            int counter = 0;
            bool found = false;
            for (int i = start; i <= end; i++)
            {
                if (found)
                    break;
                for (int y = start; y <= end; y++)
                {
                    sum = i + y;
                    counter++;
                    if (sum == magicNum)
                    {
                        found = true;
                        Console.WriteLine($"Combination N:{counter} ({i} + {y} = {magicNum})");
                        break;
                    }
                    else
                        sum++;
                }
            }
            if (!found)
                Console.WriteLine($"{counter} combinations - neither equals {magicNum}");
        }
    }
}

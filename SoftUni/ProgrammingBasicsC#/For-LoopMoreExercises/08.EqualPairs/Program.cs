using System;

namespace _08.EqualPairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool same = false;
            int input = int.Parse(Console.ReadLine());

            int sum1 = 0;
            int sum2 = 0;
            int diff = 0;
            int maxDiff = int.MinValue;
            for (int i = 0; i < input; i++)
            {
                int num = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    sum1 = num + num2;
                }
                if (i % 2 == 1)
                {
                    sum2 = num + num2;
                }

                if (sum1 == sum2)
                {
                    same = true;
                }
                else if (sum2 != sum1 && i > 0)
                {
                    same = false;
                    diff = Math.Abs(sum2 - sum1);
                    if (diff > maxDiff)
                        maxDiff = diff;
                }
                else if (input == 1)
                {
                    same = true;
                }
            }
            if (same)
                Console.WriteLine($"Yes, value={sum1}");
            else
                Console.WriteLine($"No, maxdiff={maxDiff}"); ;
        }
    }
}

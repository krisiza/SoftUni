using System;

namespace _09.LeftandRightSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            n *= 2;

            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (i < n / 2)
                {
                    sum1 += num;
                }
                else
                {
                    sum2 += num;
                }
            }

            if (sum1 == sum2)
                Console.WriteLine($"Yes, sum = {sum1}");
            else
                Console.WriteLine($"No, diff = {Math.Abs(sum1 - sum2)}");
        }
    }
}

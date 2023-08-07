using System;

namespace _05.AverageNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double input = 0;
            for (int i = 0; i < n; i++)
            {
                int n2 = int.Parse(Console.ReadLine());
                input += n2;
            }

            double result = input / n;
            Console.WriteLine($"{result:F2}");
        }
    }
}

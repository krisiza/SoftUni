using System;

namespace _05.GameOfIntervals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int turns = int.Parse(Console.ReadLine());

            double points = 0;
            double result = 0;
            double sum1 = 0;
            double sum2 = 0;
            double sum3 = 0;
            double sum4 = 0;
            double sum5 = 0;
            double sum6 = 0;
            for (int i = 1; i <= turns; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (num >= 0 && num < 10)
                {
                    result += points + (num * 0.2);
                    sum1++;
                }
                else if (num >= 10 && num < 20)
                {
                    result += points + (num * 0.3);
                    sum2++;
                }
                else if (num >= 20 && num < 30)
                {
                    result += points + (num * 0.4);
                    sum3++;
                }
                else if (num >= 30 && num < 40)
                {
                    result += points + 50;
                    sum4++;
                }
                else if (num >= 40 && num <= 50)
                {
                    result += points + 100;
                    sum5++;
                }
                else
                {
                    result /= 2;
                    sum6++;
                }
            }
            Console.WriteLine($"{(result):F2}");
            Console.WriteLine($"From 0 to 9: {(sum1 / turns * 100):F2}%");
            Console.WriteLine($"From 10 to 19: {(sum2 / turns * 100):F2}%");
            Console.WriteLine($"From 20 to 29: {(sum3 / turns * 100):F2}%");
            Console.WriteLine($"From 30 to 39: {(sum4 / turns * 100):F2}%");
            Console.WriteLine($"From 40 to 50: {(sum5 / turns * 100):F2}%");
            Console.WriteLine($"Invalid numbers: {(sum6 / turns * 100):F2}%");
        }
    }
}

using System;

namespace _11.OddEvenPosition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double oddSum = 0;
            double evenSum = 0;
            double oddMin = int.MaxValue;
            double evenMin = int.MaxValue;
            double oddMax = int.MinValue;
            double evenMax = int.MinValue;
            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenSum += num;
                    if (num > evenMax)
                    {
                        evenMax = num;
                    }
                    if (num < evenMin)
                    {
                        evenMin = num;
                    }
                }
                else if (i % 2 == 1)
                {
                    oddSum += num;
                    if (num > oddMax)
                    {
                        oddMax = num;
                    }
                    if (num < oddMin)
                    {
                        oddMin = num;
                    }
                }
            }
            Console.WriteLine($"OddSum={oddSum:F2},");
            if (oddMin == int.MaxValue)
                Console.WriteLine("OddMin=No,");
            else
                Console.WriteLine($"OddMin={oddMin:F2},");
            if (oddMax == int.MinValue)
                Console.WriteLine("OddMax=No,");
            else
                Console.WriteLine($"OddMax={oddMax:F2},");
            Console.WriteLine($"EvenSum={evenSum:F2},");
            if (evenMin == int.MaxValue)
                Console.WriteLine("EvenMin=No,");
            else
                Console.WriteLine($"EvenMin={evenMin:F2},");
            if (evenMax == int.MinValue)
                Console.WriteLine("EvenMax=No");
            else
                Console.WriteLine($"EvenMax={evenMax:F2}");
        }
    }
}

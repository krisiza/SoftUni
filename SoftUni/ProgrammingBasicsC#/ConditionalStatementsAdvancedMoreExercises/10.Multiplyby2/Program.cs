using System;

namespace _10.Multiplyby2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double number = 0;
            bool negativNumber = false;
            do
            {
                number = double.Parse(Console.ReadLine());
                double result = number * 2;
                if (result > -1)
                    Console.WriteLine($"Result: {result:F2}");
                else
                {
                    Console.WriteLine("Negative number!");
                    negativNumber = true;
                }

            }
            while (!negativNumber);
        }
    }
}

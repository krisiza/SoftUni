using System;

namespace _02.PoundsToDollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pound = int.Parse(Console.ReadLine());
            double dollar = pound * 1.31;
            Console.WriteLine($"{dollar:f3}");
        }
    }
}

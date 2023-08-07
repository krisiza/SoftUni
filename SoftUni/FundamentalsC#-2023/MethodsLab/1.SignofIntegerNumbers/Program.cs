using System;

namespace _1.SignofIntegerNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            NumberCheck(number);
        }
        static void NumberCheck(int number)
        {
            if (number == 0)
                Console.WriteLine($"The number {number} is zero.");
            else if (number > 0)
                Console.WriteLine($"The number {number} is positive.");
            else if (number < 0)
                Console.WriteLine($"The number {number} is negative.");
        }
    }
}

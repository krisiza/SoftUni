using System;

namespace _01.SmallestofThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            Console.WriteLine(GetSmallestNumber(num1, num2, num3));
        }
        private static int GetSmallestNumber(int number1, int number2, int number3)
        {
            return Math.Min(number1, Math.Min(number2, number3));
        }
    }
}

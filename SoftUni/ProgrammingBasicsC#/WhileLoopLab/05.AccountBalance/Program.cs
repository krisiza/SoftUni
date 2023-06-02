using System;

namespace _05.AccountBalance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double balance = 0;
            bool minus = false;
            var input = Console.ReadLine();
            double num = 0;
            do
            {
                num = double.Parse(input);
                if (num < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                else
                {
                    balance += num;
                    Console.WriteLine($"Increase: {num:F2}");
                    input = Console.ReadLine();
                }
            }
            while (input != "NoMoreMoney");

            Console.WriteLine($"Total: {balance:F2}");
        }
    }
}

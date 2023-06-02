using System;

namespace _03.DepositCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double depo = double.Parse(Console.ReadLine());
            double term = double.Parse(Console.ReadLine());
            double interest = double.Parse(Console.ReadLine());

            double interest2 = depo * (interest / 100);
            double monthInterest = interest2 / 12;
            double sum = depo + term * monthInterest;
            Console.WriteLine(sum);
        }
    }
}

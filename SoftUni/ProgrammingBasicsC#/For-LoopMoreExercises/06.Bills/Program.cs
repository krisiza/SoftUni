using System;

namespace _06.Bills
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());

            double sum = 0;
            double sumE = 0;
            double sumW = 0;
            double sumI = 0;
            double sumR = 0;
            for (int i = 1; i <= months; i++)
            {
                double e = double.Parse(Console.ReadLine());

                sumE += e;
                sumW += 20;
                sumI += 15;
                sumR += (e + 20 + 15) + ((e + 20 + 15) * 0.2);
            }
            sum = sumE + sumW + sumI + sumR;

            Console.WriteLine($"Electricity: {(sumE):F2} lv");
            Console.WriteLine($"Water: {(sumW):F2} lv");
            Console.WriteLine($"Internet: {(sumI):F2} lv");
            Console.WriteLine($"Other: {(sumR):F2} lv");
            Console.WriteLine($"Average: {(sum / months):F2} lv");
        }
    }
}

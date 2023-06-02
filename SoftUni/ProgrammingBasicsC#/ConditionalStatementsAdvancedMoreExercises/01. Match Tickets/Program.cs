using System;

namespace _01._Match_Tickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int group = int.Parse(Console.ReadLine());


            double transport = 0;
            if (group >= 1 && group <= 4)
            {
                transport = budget * 0.75;
            }
            else if (group >= 5 && group <= 9)
            {
                transport = budget * 0.60;
            }
            else if (group >= 10 && group <= 24)
            {
                transport = budget * 0.50;
            }
            else if (group >= 25 && group <= 49)
            {
                transport = budget * 0.40;
            }
            else
            {
                transport = budget * 0.25;
            }

            double rest = budget - transport;
            double ticket = category == "VIP" ? 499.99 : 249.99;
            double sumPrice = ticket * group;
            double moneyleft = Math.Abs(rest - sumPrice);

            if (sumPrice <= rest)
            {
                Console.WriteLine($"Yes! You have {moneyleft:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {moneyleft:F2} leva.");
            }
        }
    }
}

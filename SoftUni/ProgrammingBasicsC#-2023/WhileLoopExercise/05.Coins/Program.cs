using System;

namespace _05.Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal input = decimal.Parse(Console.ReadLine());
            decimal lv = Math.Floor(input);
            decimal coins = Math.Round((input - lv) * 100);
            int coinscounter = 0;
            while (lv > 0)
            {
                while (lv >= 2)
                {
                    lv -= 2;
                    coinscounter++;
                }
                while (lv >= 1)
                {
                    lv -= 1;
                    coinscounter++;
                }
            }

            while (coins > 0)
            {
                while (coins >= 50)
                {
                    coins -= 50;
                    coinscounter++;
                }
                while (coins >= 20)
                {
                    coins -= 20;
                    coinscounter++;
                }
                while (coins >= 10)
                {
                    coins -= 10;
                    coinscounter++;
                }
                while (coins >= 5)
                {
                    coins -= 5;
                    coinscounter++;
                }
                while (coins >= 2)
                {
                    coins -= 2;
                    coinscounter++;
                }
                while (coins >= 1)
                {
                    coins -= 1;
                    coinscounter++;
                }
            }
            Console.WriteLine(coinscounter);
        }
    }
}

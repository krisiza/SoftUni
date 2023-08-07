using System;

namespace _08.FuelTankPart2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fuel = Console.ReadLine();
            double lfuel = double.Parse(Console.ReadLine());
            string clubCard = Console.ReadLine();
            double price = 0;
            double lPriceFuel = 0;
            bool disCard = false;
            double disCardPrice = 0;
            double disLPriceProzent = 0;
            double disLPrice = 0;

            if (lfuel < 1 || lfuel > 50)
            {
                return;
            }

            switch (fuel)
            {
                case "Gas":
                    lPriceFuel = 0.93;
                    disCardPrice = 0.08;
                    if (clubCard == "Yes")
                        disCard = true;
                    break;
                case "Diesel":
                    lPriceFuel = 2.33;
                    disCardPrice = 0.12;
                    if (clubCard == "Yes")
                        disCard = true;
                    break;
                case "Gasoline":
                    lPriceFuel = 2.22;
                    disCardPrice = 0.18;
                    if (clubCard == "Yes")
                        disCard = true;
                    break;
                default:
                    return;
            }

            if (lfuel > 25)
            {
                disLPriceProzent = 10;
            }
            if (lfuel <= 25 && lfuel >= 20)
            {
                disLPriceProzent = 8;
            }

            if (disCard)
            {
                price = lfuel * (lPriceFuel - disCardPrice);
                if (disLPriceProzent != 0)
                {
                    disLPrice = price * (disLPriceProzent / 100);
                }
                price -= disLPrice;

                Console.WriteLine($"{price:F2} lv.");
                return;

            }
            else
            {
                price = lfuel * lPriceFuel;
                if (disLPriceProzent != 0)
                {
                    disLPrice = price * (disLPriceProzent / 100);
                }
                price -= disLPrice;

                Console.WriteLine($"{price:F2} lv.");
                return;
            }
        }
    }
}

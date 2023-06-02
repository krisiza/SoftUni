using System;

namespace _02.BikeRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bikerJ = int.Parse(Console.ReadLine());
            int bikerS = int.Parse(Console.ReadLine());
            string race = Console.ReadLine();

            double priceJ = 0;
            double priceS = 0;
            switch (race)
            {
                case "trail":
                    priceJ = 5.5;
                    priceS = 7;
                    break;
                case "cross-country":
                    priceJ = 8;
                    priceS = 9.5;
                    break;
                case "downhill":
                    priceJ = 12.25;
                    priceS = 13.75;
                    break;
                case "road":
                    priceJ = 20;
                    priceS = 21.5;
                    break;
            }

            double priceSumJ = bikerJ * priceJ;
            double priceSumS = bikerS * priceS;
            double priceSum = priceSumJ + priceSumS;

            if (bikerJ + bikerS >= 50 && race == "cross-country")
            {
                double discount = priceSum * 25 / 100;
                priceSum -= discount;
            }

            double expen = priceSum * 5 / 100;
            priceSum -= expen;

            Console.WriteLine($"{priceSum:F2}");
        }
    }
}

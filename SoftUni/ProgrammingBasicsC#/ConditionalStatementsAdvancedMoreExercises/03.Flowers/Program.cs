using System;

namespace _03.Flowers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chrysanthemum = int.Parse(Console.ReadLine());
            int rose = int.Parse(Console.ReadLine());
            int tulip = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string holyday = Console.ReadLine();

            double chrysanthemumPrice = 0;
            double rosePrice = 0;
            double tulipPrice = 0;
            switch (season)
            {
                case "Spring":
                case "Summer":
                    chrysanthemumPrice = 2;
                    rosePrice = 4.1;
                    tulipPrice = 2.5;
                    break;
                case "Autumn":
                case "Winter":
                    chrysanthemumPrice = 3.75;
                    rosePrice = 4.5;
                    tulipPrice = 4.15;
                    break;
            }

            tulipPrice = tulip * tulipPrice;
            rosePrice = rose * rosePrice;
            chrysanthemumPrice = chrysanthemum * chrysanthemumPrice;
            int bouquet = tulip + chrysanthemum + rose;
            double bouquetPrice = tulipPrice + chrysanthemumPrice + rosePrice;
            if (holyday == "Y")
            {
                double increase = bouquetPrice * 0.15;
                bouquetPrice += increase;

            }
            double discount = 0;
            if (tulip > 7 && season == "Spring")
            {
                discount = bouquetPrice * 0.05;
                bouquetPrice -= discount;
            }
            if (rose >= 10 && season == "Winter")
            {
                discount = bouquetPrice * 0.1;
                bouquetPrice -= discount;
            }
            if (bouquet > 20)
            {
                discount = bouquetPrice * 0.2;
                bouquetPrice -= discount;
            }

            bouquetPrice += 2;

            Console.WriteLine($"{bouquetPrice:F2}");
        }
    }
}

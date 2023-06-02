using System;

namespace _03.NewHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int flowerMenge = int.Parse(Console.ReadLine());
            int buget = int.Parse(Console.ReadLine());
            int Procent = 0;
            double flowerPrice = 0;
            bool discount = true;

            if (flower == "Roses")
            {
                flowerPrice = 5;
                if (flowerMenge > 80) Procent = 10;
            }
            if (flower == "Dahlias")
            {
                flowerPrice = 3.8;
                if (flowerMenge > 90) Procent = 15;
            }
            if (flower == "Tulips")
            {
                flowerPrice = 2.8;
                if (flowerMenge > 80) Procent = 15;
            }
            if (flower == "Narcissus")
            {
                flowerPrice = 3;
                if (flowerMenge < 120)
                {
                    Procent = 15;
                    discount = false;
                }
            }
            if (flower == "Gladiolus")
            {
                flowerPrice = 2.5;
                if (flowerMenge < 80)
                {
                    Procent = 20;
                    discount = false;
                }
            }

            double DiscountorPlus = (flowerPrice * Procent) / 100;

            if (discount)
            {
                flowerPrice -= DiscountorPlus;
            }
            else
            {
                flowerPrice += DiscountorPlus;
            }

            double totalPrice = flowerMenge * flowerPrice;
            double rest = buget - totalPrice;
            if (totalPrice > buget)
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(rest):F2} leva more.");
            }
            else if (totalPrice <= buget)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowerMenge} {flower} and {Math.Abs(rest):F2} leva left.");
            }
        }
    }
}

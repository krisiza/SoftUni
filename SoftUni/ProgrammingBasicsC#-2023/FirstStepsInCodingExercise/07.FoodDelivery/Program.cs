using System;

namespace _07.FoodDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chickenMenu = int.Parse(Console.ReadLine());
            int fishMenu = int.Parse(Console.ReadLine());
            int vegMenu = int.Parse(Console.ReadLine());

            double priceChicken = chickenMenu * 10.35;
            double priceFish = fishMenu * 12.40;
            double priceVeg = vegMenu * 8.15;

            double sum = priceChicken + priceFish + priceVeg;
            double des = (sum * 20) / 100;
            Console.WriteLine(sum + des + 2.50);
        }
    }
}

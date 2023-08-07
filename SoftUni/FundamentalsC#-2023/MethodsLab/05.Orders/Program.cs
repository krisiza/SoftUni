using System;

namespace _05.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            Console.WriteLine($"{CalculateTotalPrice(product, quantity):f2}");
        }
        static double CalculateTotalPrice(string product, int quantity)
        {
            double price = 0;

            switch (product)
            {
                case "coffee":
                    price = 1.5 * (double)quantity;
                    break;
                case "water":
                    price = 1 * (double)quantity;
                    break;
                case "coke":
                    price = 1.4 * (double)quantity;
                    break;
                case "snacks":
                    price = 2 * (double)quantity;
                    break;
            }

            return price;
        }
    }
}

using System;

namespace _08.PetShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double price = double.Parse(Console.ReadLine());
            double price2 = double.Parse(Console.ReadLine());

            price *= 2.5;
            price2 *= 4;

            Console.WriteLine(price + price2 + " lv.");
        }
    }
}

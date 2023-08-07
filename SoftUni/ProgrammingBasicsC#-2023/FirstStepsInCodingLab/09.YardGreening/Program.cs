using System;

namespace _09.YardGreening
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double cm2 = Convert.ToDouble(Console.ReadLine());

            double price = cm2 * 7.61;
            double discount = price * 0.18;
            double finalPrice = price - discount;

            Console.WriteLine($"The final price is: {finalPrice} lv.The discount is: {discount} lv.");
        }
    }
}

using System;

namespace _11.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int orders = int.Parse(Console.ReadLine());
            int counter = 0;

            double totalPrice = 0;

            while (counter < orders) 
            {
                double price = 0;
                double priceCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int numberOfCapsules = int.Parse(Console.ReadLine());

                price = ((days * numberOfCapsules) * priceCapsule);

                Console.WriteLine($"The price for the coffee is: ${price:f2}");
                totalPrice += price;

                counter++;
            }
            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}

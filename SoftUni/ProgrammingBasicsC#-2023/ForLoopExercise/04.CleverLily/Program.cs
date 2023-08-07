using System;

namespace _04.CleverLily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            double sum = 0;
            double money = 10;
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 1)
                {
                    sum += toyPrice;
                }
                else if (i % 2 == 0)
                {
                    sum += money;
                    money += 10;
                    sum -= 1;
                }
            }

            if (sum >= price)
                Console.WriteLine($"Yes! {(sum - price):F2}");
            else
                Console.WriteLine($"No! {(price - sum):F2}");
        }
    }
}

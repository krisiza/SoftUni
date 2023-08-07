using System;

namespace _04.Transport_Price
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int km = int.Parse(Console.ReadLine());
            string dayORnighth = Console.ReadLine();
            double price = 0;

            if (km < 20)
            {
                switch (dayORnighth)
                {
                    case "day":
                        price = 0.70 + km * 0.79;
                        break;
                    case "night":
                        price = 0.70 + km * 0.90;
                        break;
                }
            }
            else if (km >= 20 && km < 100)
            {
                price = km * 0.09;
            }
            else if (km >= 100)
            {
                price = km * 0.06;
            }

            Console.WriteLine($"{price:F2}");
        }
    }
}

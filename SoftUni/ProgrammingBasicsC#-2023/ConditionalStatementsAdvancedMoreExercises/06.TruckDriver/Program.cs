using System;

namespace _06.TruckDriver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double km = double.Parse(Console.ReadLine());

            double priceKm = 0;
            switch (season)
            {
                case "Spring":
                case "Autumn":
                    if (km <= 5000)
                        priceKm = 0.75;
                    else if (km > 5000 && km <= 10000)
                        priceKm = 0.95;
                    else if (km > 10000 && km <= 20000)
                        priceKm = 1.45;
                    break;
                case "Summer":
                    if (km <= 5000)
                        priceKm = 0.9;
                    else if (km > 5000 && km <= 10000)
                        priceKm = 1.1;
                    else if (km > 10000 && km <= 20000)
                        priceKm = 1.45;
                    break;
                case "Winter":
                    if (km <= 5000)
                        priceKm = 1.05;
                    else if (km > 5000 && km <= 10000)
                        priceKm = 1.25;
                    else if (km > 10000 && km <= 20000)
                        priceKm = 1.45;
                    break;
            }

            double salary = priceKm * km;
            double salary4Months = salary * 4;
            double tax = salary4Months * 0.1;
            salary4Months -= tax;

            Console.WriteLine($"{salary4Months:F2}");
        }
    }
}

using System;

namespace _04.CarToGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string classType = "";
            string carType = "";
            double priceProcent = 0;
            if (budget <= 100)
            {
                classType = "Economy class";
                if (season == "Winter")
                {
                    carType = "Jeep";
                    priceProcent = 0.65;
                }
                else if (season == "Summer")
                {
                    carType = "Cabrio";
                    priceProcent = 0.35;
                }
            }
            else if (budget > 100 && budget <= 500)
            {
                classType = "Compact class";
                if (season == "Winter")
                {
                    carType = "Jeep";
                    priceProcent = 0.8;
                }
                else if (season == "Summer")
                {
                    carType = "Cabrio";
                    priceProcent = 0.45;
                }
            }
            else if (budget > 500)
            {
                classType = "Luxury class";

                carType = "Jeep";
                priceProcent = 0.9;
            }

            double carPrice = budget * priceProcent;
            Console.WriteLine(classType);
            Console.WriteLine($"{carType} - {carPrice:F2}");
        }
    }
}

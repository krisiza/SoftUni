using System;

namespace _05.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string residence = "";
            string destination = "";
            double priceProcent = 0;
            if (budget <= 1000)
            {
                residence = "Camp";
                if (season == "Winter")
                {
                    destination = "Morocco";
                    priceProcent = 0.45;
                }
                else if (season == "Summer")
                {
                    destination = "Alaska";
                    priceProcent = 0.65;
                }
            }
            else if (budget > 1000 && budget <= 3000)
            {
                residence = "Hut";
                if (season == "Winter")
                {
                    destination = "Morocco";
                    priceProcent = 0.6;
                }
                else if (season == "Summer")
                {
                    destination = "Alaska";
                    priceProcent = 0.8;
                }
            }
            else if (budget > 3000)
            {
                residence = "Hotel";
                if (season == "Winter")
                    destination = "Morocco";
                else if (season == "Summer")
                    destination = "Alaska";
                priceProcent = 0.9;
            }

            Console.WriteLine($"{destination} - {residence} - {(budget * priceProcent):F2}");
        }
    }
}

using System;

namespace _05.Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double buget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = "";
            string typeJourney = "";
            int procentExpenses = 0;
            bool isSummer = false;

            if (season == "summer")
            {
                isSummer = true;
                typeJourney = "Camp";
            }
            else
            {
                typeJourney = "Hotel";
            }

            if (buget <= 100)
            {
                destination = "Bulgaria";
                if (isSummer)
                    procentExpenses = 30;
                else
                    procentExpenses = 70;
            }
            else if (buget <= 1000)
            {
                destination = "Balkans";
                if (isSummer)
                    procentExpenses = 40;
                else
                    procentExpenses = 80;
            }
            else if (buget > 1000)
            {
                destination = "Europe";
                typeJourney = "Hotel";
                procentExpenses = 90;
            }

            double priceJ = (buget * procentExpenses) / 100;

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{typeJourney} - {priceJ:F2}");
        }
    }
}

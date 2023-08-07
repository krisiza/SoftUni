using System;

namespace _04.FishingBoat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int buget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fisherman = int.Parse(Console.ReadLine());
            bool isAutumn = false;

            double price = 0;
            int disProcent = 10;
            int dis2Procent = 0;

            switch (season)
            {
                case "Spring":
                    price = 3000;
                    break;
                case "Summer":
                    price = 4200;
                    break;
                case "Autumn":
                    isAutumn = true;
                    price = 4200;
                    break;
                case "Winter":
                    price = 2600;
                    break;
            }
            if (fisherman >= 7 && fisherman <= 11)
                disProcent = 15;
            if (fisherman >= 12)
                disProcent = 25;

            if (!isAutumn && fisherman % 2 == 0)
            {
                dis2Procent = 5;
            }

            double discount = (price * disProcent) / 100;
            price -= discount;
            double discount2 = (price * dis2Procent) / 100;
            price -= discount2;

            double rest = buget - price;

            if (buget >= price)
            {
                Console.WriteLine($"Yes! You have {Math.Abs(rest):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(rest):F2} leva.");
            }
        }
    }
}

using System;

namespace _07.HotelRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double PriceApartamentNight = 0;
            double PriceStudioNight = 0;
            double discountStudioNight = 0;
            double discountApartamentNight = 0;

            switch (month)
            {
                case "May":
                case "October":
                    PriceApartamentNight = 65;
                    PriceStudioNight = 50;
                    if (nights > 7 && nights <= 14)
                    {
                        discountStudioNight = 5;
                    }
                    else if (nights > 14)
                    {
                        discountStudioNight = 30;
                        discountApartamentNight = 10;
                    }
                    break;
                case "June":
                case "September":
                    PriceApartamentNight = 68.7;
                    PriceStudioNight = 75.2;
                    if (nights > 14)
                    {
                        discountStudioNight = 20;
                        discountApartamentNight = 10;
                    }
                    break;
                case "July":
                case "August":
                    PriceApartamentNight = 77;
                    PriceStudioNight = 76;
                    if (nights > 14)
                    {
                        discountApartamentNight = 10;
                    }
                    break;
            }
            double totalPriceApartament = 0;
            double totalPriceStudio = 0;
            if (discountApartamentNight != 0)
            {
                double discountA = PriceApartamentNight * discountApartamentNight / 100;
                PriceApartamentNight -= discountA;
                totalPriceApartament = nights * PriceApartamentNight;
            }
            else
            {
                totalPriceApartament = nights * PriceApartamentNight;
            }

            if (discountStudioNight != 0)
            {
                double discountS = PriceStudioNight * discountStudioNight / 100;
                PriceStudioNight -= discountS;
                totalPriceStudio = nights * PriceStudioNight;
            }
            else
            {
                totalPriceStudio = nights * PriceStudioNight;
            }

            Console.WriteLine($"Apartment: {totalPriceApartament:F2} lv.");
            Console.WriteLine($"Studio: {totalPriceStudio:F2} lv.");
        }
    }
}

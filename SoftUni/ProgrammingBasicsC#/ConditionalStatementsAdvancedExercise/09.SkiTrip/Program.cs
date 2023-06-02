using System;

namespace _09.SkiTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dayResidence = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string note = Console.ReadLine();

            dayResidence -= 1;
            double nighthPrice = 0;
            double disResidence = 0;

            switch (roomType)
            {
                case "room for one person":
                    nighthPrice = 18;
                    break;
                case "apartment":
                    nighthPrice = 25;
                    if (dayResidence < 10)
                    {
                        disResidence = 30;
                    }
                    else if (dayResidence >= 10 && dayResidence <= 15)
                    {
                        disResidence = 35;
                    }
                    else if (dayResidence > 15)
                    {
                        disResidence = 50;
                    }
                    break;
                case "president apartment":
                    nighthPrice = 35;
                    if (dayResidence < 10)
                    {
                        disResidence = 10;
                    }
                    else if (dayResidence >= 10 && dayResidence <= 15)
                    {
                        disResidence = 15;
                    }
                    else if (dayResidence > 15)
                    {
                        disResidence = 20;
                    }
                    break;
            }

            double sum = dayResidence * nighthPrice;
            double discount = sum * disResidence / 100;
            sum -= discount;

            int plusDis = 0;
            double pricePlusorMin;
            if (note == "positive")
            {
                plusDis = 25;
                pricePlusorMin = sum * plusDis / 100;
                sum += pricePlusorMin;
            }
            else if (note == "negative")
            {
                plusDis = 10;
                pricePlusorMin = sum * plusDis / 100;
                sum -= pricePlusorMin;
            }
            Console.WriteLine($"{sum:F2}");
        }
    }
}

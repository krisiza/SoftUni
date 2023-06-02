using System;

namespace _07.SchoolCamp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string groupType = Console.ReadLine();
            int groupNum = int.Parse(Console.ReadLine());
            int nightsNum = int.Parse(Console.ReadLine());

            bool winter = false;
            bool summer = false;
            bool spring = false;
            double nightPrice = 0;
            switch (season)
            {
                case "Winter":
                    if (groupType == "boys" || groupType == "girls")
                        nightPrice = 9.6;
                    else if (groupType == "mixed")
                        nightPrice = 10;
                    winter = true;
                    break;
                case "Spring":
                    if (groupType == "boys" || groupType == "girls")
                        nightPrice = 7.2;
                    else if (groupType == "mixed")
                        nightPrice = 9.5;
                    spring = true;
                    break;
                case "Summer":
                    if (groupType == "boys" || groupType == "girls")
                        nightPrice = 15;
                    else if (groupType == "mixed")
                        nightPrice = 20;
                    summer = true;
                    break;
            }

            double discount = 0;
            if (groupNum >= 50)
                discount = 0.5;
            else if (groupNum < 50 && groupNum >= 20)
                discount = 0.15;
            else if (groupNum < 20 && groupNum >= 10)
                discount = 0.05;

            double priceSum = nightPrice * groupNum * nightsNum;
            if (discount != 0)
            {
                double disPrice = priceSum * discount;
                priceSum -= disPrice;
            }

            string sport = "";

            if (winter && groupType == "girls")
                sport = "Gymnastics";
            else if (winter && groupType == "boys")
                sport = "Judo";
            else if (winter && groupType == "mixed")
                sport = "Ski";

            if (spring && groupType == "girls")
                sport = "Athletics";
            else if (spring && groupType == "boys")
                sport = "Tennis";
            else if (spring && groupType == "mixed")
                sport = "Cycling";

            if (summer && groupType == "girls")
                sport = "Volleyball";
            else if (summer && groupType == "boys")
                sport = "Football";
            else if (summer && groupType == "mixed")
                sport = "Swimming";

            Console.WriteLine($"{sport} {priceSum:F2} lv.");
        }
    }
}

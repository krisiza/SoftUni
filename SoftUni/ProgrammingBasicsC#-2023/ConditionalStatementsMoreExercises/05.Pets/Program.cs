using System;

namespace _05.Pets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int foodKg = int.Parse(Console.ReadLine());
            double dogFoodKg = double.Parse(Console.ReadLine());
            double catFoodKg = double.Parse(Console.ReadLine());
            double turtleFoodGr = double.Parse(Console.ReadLine());

            double dogNeedKg = days * dogFoodKg;
            double catNeedKg = days * catFoodKg;
            double turtleNeedKg = days * (turtleFoodGr / 1000);

            double sumFoodKg = dogNeedKg + catNeedKg + turtleNeedKg;

            if (sumFoodKg <= foodKg)
            {
                int rest = (int)(sumFoodKg - foodKg);
                Console.WriteLine($"{Math.Abs(rest)} kilos of food left.");
            }
            else
            {
                double rest = Math.Ceiling(sumFoodKg - foodKg);
                Console.WriteLine($"{Math.Abs(rest)} more kilos of food are needed.");
            }
        }
    }
}

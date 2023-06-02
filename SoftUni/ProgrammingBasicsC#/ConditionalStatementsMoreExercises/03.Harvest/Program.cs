using System;

namespace _03.Harvest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int area = int.Parse(Console.ReadLine());
            double grapes = double.Parse(Console.ReadLine());
            int wineL = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double sumGrapes = area * grapes;
            double wine = ((sumGrapes * 40) / 100) / 2.5;

            if (wineL <= wine)
            {
                double rest = Math.Ceiling(wine - wineL);
                double restforWorkers = Math.Ceiling(rest / workers);

                Console.WriteLine($"Good harvest this year! Total wine: {(int)wine} liters.");
                Console.WriteLine($"{rest} liters left -> {restforWorkers} liters per person.");
            }
            else
            {
                int rest = (int)(wineL - wine);
                Console.WriteLine($"It will be a tough winter! More {rest} liters wine needed.");
            }
        }
    }
}

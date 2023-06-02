using System;

namespace _06.Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double folie = int.Parse(Console.ReadLine());
            double paint = int.Parse(Console.ReadLine());
            double thinner = int.Parse(Console.ReadLine());
            double hours = int.Parse(Console.ReadLine());

            double foliePrice = (folie + 2) * 1.50;
            double extraPaint = (paint * 10) / 100;
            double paintPrice = (paint + extraPaint) * 14.50;
            double thinnerPrice = thinner * 5;

            double sum = foliePrice + paintPrice + thinnerPrice + 0.40;
            double workPrice = (sum * 30) / 100;
            workPrice *= hours;
            Console.WriteLine(workPrice + sum);
        }
    }
}

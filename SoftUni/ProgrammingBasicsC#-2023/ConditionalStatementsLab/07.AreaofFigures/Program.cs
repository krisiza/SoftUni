using System;

namespace _07.AreaofFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            if (figure == "square")
            {
                double x = double.Parse(Console.ReadLine());
                Console.WriteLine($"{(x * x):F3}");
            }
            if (figure == "rectangle")
            {
                double x = double.Parse(Console.ReadLine());
                double y = double.Parse(Console.ReadLine());
                Console.WriteLine($"{(x * y):F3}");
            }
            if (figure == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                double area = Math.PI * (r * r);
                Console.WriteLine($"{area:F3}");
            }
            if (figure == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                double area = (a * h) / 2;
                Console.WriteLine($"{area:F3}");
            }
        }
    }
}

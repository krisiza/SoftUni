using System;

namespace _02.CenterPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            FindNearestPoint(x1,y1,x2,y2);
        }
        static void FindNearestPoint(double x1, double y1, double x2, double y2)
        {
            double point1 = Math.Sqrt(Math.Abs(x1 * x1) + Math.Abs(y1 * y1));
            double point2 = Math.Sqrt(Math.Abs(x2 * x2) + Math.Abs(y2 * y2));

            if (point1 <= point2)
                Console.WriteLine($"({x1}, {y1})");
            else
                Console.WriteLine($"({x2}, {y2})");

        }
    }
}

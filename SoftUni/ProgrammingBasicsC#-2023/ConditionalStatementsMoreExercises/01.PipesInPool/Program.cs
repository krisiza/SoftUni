using System;

namespace _01.PipesInPool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int volume = int.Parse(Console.ReadLine());
            int p1 = int.Parse(Console.ReadLine());
            int p2 = int.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double p1L = p1 * h;
            double p2L = p2 * h;

            double water = p1L + p2L;
            double waterP = (water / volume) * 100;
            double p1P = (p1L / water) * 100;
            double p2P = (p2L / water) * 100;

            if (water <= volume)
            {
                Console.WriteLine($"The pool is {waterP}% full. Pipe 1: {p1P:F2}. Pipe 2: {p2P:F2}.");
            }
            else
            {
                Console.WriteLine($"For {h:F2} hours the pool overflows with {Math.Abs(volume - water):F2} liters.");
            }
        }
    }
}

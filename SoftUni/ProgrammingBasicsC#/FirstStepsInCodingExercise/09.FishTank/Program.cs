using System;

namespace _09.FishTank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int legth = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double prozent = double.Parse(Console.ReadLine());

            double volume = legth * width * height;
            double lVolume = volume / 1000;
            double occuSpace = prozent / 100;
            double water = lVolume * (1 - occuSpace);
            Console.WriteLine(water);
        }
    }
}

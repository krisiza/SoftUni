using System;

namespace _07.WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            int tank = 255;
            int sumWater = 0;
            for (int i = 0; i < lines; i++)
            {
                int quantitiesWater = int.Parse(Console.ReadLine());

                if (quantitiesWater <= tank)
                {
                    tank -= quantitiesWater;
                    sumWater += quantitiesWater;
                }
                else
                    Console.WriteLine("Insufficient capacity!");
            }
            Console.WriteLine(sumWater);
        }
    }
}

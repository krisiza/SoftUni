using System;

namespace _07.FuelTank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fuel = Console.ReadLine();
            double lfuel = double.Parse(Console.ReadLine());

            if (fuel == "Diesel" || fuel == "Gas" || fuel == "Gasoline")
            {
                if (lfuel >= 25)
                {
                    Console.WriteLine($"You have enough {fuel.ToLower()}.");
                }
                else if (lfuel < 25)
                {
                    Console.WriteLine($"Fill your tank with {fuel.ToLower()}!");
                }
            }
            else
            {
                Console.WriteLine("Invalid fuel!");
            }
        }
    }
}

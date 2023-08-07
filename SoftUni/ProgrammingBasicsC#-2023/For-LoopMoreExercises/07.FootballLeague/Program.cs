using System;

namespace _07.FootballLeague
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double stadium = int.Parse(Console.ReadLine());
            int fans = int.Parse(Console.ReadLine());

            double sumA = 0;
            double sumB = 0;
            double sumV = 0;
            double sumG = 0;
            for (int i = 1; i <= fans; i++)
            {
                string sector = Console.ReadLine();

                switch (sector)
                {
                    case "A":
                        sumA++;
                        break;
                    case "B":
                        sumB++;
                        break;
                    case "V":
                        sumV++;
                        break;
                    case "G":
                        sumG++;
                        break;
                }
            }

            Console.WriteLine($"{(sumA / fans * 100):F2}%");
            Console.WriteLine($"{(sumB / fans * 100):F2}%");
            Console.WriteLine($"{(sumV / fans * 100):F2}%");
            Console.WriteLine($"{(sumG / fans * 100):F2}%");
            Console.WriteLine($"{(fans / stadium * 100):F2}%");
        }
    }
}

using System;

namespace _06.WeddingSeats
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char sector = char.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            int places = int.Parse(Console.ReadLine());

            int evenplaces = places;
            int oddplaces = places + 2;
            int counter = 0;
            for (int i = 65; i <= sector; i++)
            {
                for (int y = 1; y <= rows; y++)
                {
                    for (int j = 97; j <= 96 + places; j++)
                    {
                        Console.Write(((char)i));
                        Console.Write(y);
                        Console.Write(((char)j));
                        if (y % 2 == 0)
                            places = oddplaces;
                        else
                            places = evenplaces;
                        counter++;
                        Console.WriteLine();
                    }
                }
                rows++;
            }
            Console.WriteLine(counter);
        }
    }
}

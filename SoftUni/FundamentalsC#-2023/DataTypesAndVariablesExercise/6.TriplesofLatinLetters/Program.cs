using System;

namespace _6.TriplesofLatinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++) 
            {
                for(int j = 0; j < n; j++)
                {
                    for(int k = 0; k < n; k++) 
                    {
                        char firstChart = (char)('a' + i);
                        char secondChart = (char)('a' + j);
                        char thirdChart = (char)('a' + k);
                        Console.Write(firstChart);
                        Console.Write(secondChart);
                        Console.Write(thirdChart);
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}

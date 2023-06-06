using System;
using System.Linq;

namespace _2.CarRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            double sumPlayer1 = 0, sumPlayer2 = 0;

            for (int i = 0; i < numbers.Length / 2; i++)
            {
                if (numbers[i] == 0)
                    sumPlayer1 *= 0.8;
                else
                    sumPlayer1 += numbers[i];
            }
            for (int i = numbers.Length - 1; i > numbers.Length / 2; i--)
            {
                if (numbers[i] == 0)
                    sumPlayer2 *= 0.8;
                else
                    sumPlayer2 += numbers[i];
            }


            if (sumPlayer1 > sumPlayer2)
                Console.WriteLine($"The winner is right with total time: {sumPlayer2}");
            else
                Console.WriteLine($"The winner is left with total time: {sumPlayer1}");
        }
    }
}


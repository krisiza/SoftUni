using System;

namespace _04.SumofChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numLines = int.Parse(Console.ReadLine());

            int totalSum = 0;
            for(int i = 0; i < numLines; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                totalSum += letter;
            }
            Console.WriteLine($"The sum equals: {totalSum}");
        }
    }
}

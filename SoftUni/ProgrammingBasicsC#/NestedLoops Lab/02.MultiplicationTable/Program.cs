using System;

namespace _02.MultiplicationTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int y = 1; y <= 10; y++)
                {
                    Console.WriteLine($"{i} * {y} = {i * y}");
                }
            }
        }
    }
}

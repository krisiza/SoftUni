﻿using System;

namespace _05.Number100_200
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            if (num > 200)
            {
                Console.WriteLine("Greater than 200");
            }
            else if (num <= 200 && num >= 100)
            {
                Console.WriteLine("Between 100 and 200");
            }
            else if (num < 100)
            {
                Console.WriteLine("Less than 100");
            }
        }
    }
}
﻿using System;

namespace _01.Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int column = int.Parse(Console.ReadLine());
            double price = 0;

            if (type == "Premiere")
                price = 12;
            else if (type == "Normal")
                price = 7.5;
            else if (type == "Discount")
                price = 5;

            double income = (row * column) * price;
            Console.WriteLine($"{income:F2} leva.");
        }
    }
}

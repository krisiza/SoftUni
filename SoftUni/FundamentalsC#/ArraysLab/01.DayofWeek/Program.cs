﻿using System;

namespace _01.DayofWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] days = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            int num = int.Parse(Console.ReadLine());

            if (num > days.Length || num < 1)
                Console.WriteLine("Invalid day!");
            else
                Console.WriteLine(days[num - 1]);
        }
    }
}

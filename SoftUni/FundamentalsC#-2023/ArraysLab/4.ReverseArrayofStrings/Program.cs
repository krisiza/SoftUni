﻿using System;

namespace _4.ReverseArrayofStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(' ');

            for(int i = strings.Length-1;i >=0;i--) 
            {
                Console.Write(strings[i] + " ");
            }
        }
    }
}

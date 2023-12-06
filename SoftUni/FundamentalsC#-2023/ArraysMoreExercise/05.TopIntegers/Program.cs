﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TopIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            for(int i = 0; i < arr.Length; i++) 
            {
                bool isTop = true;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i] <= arr[j])
                    {
                        isTop = false;
                        break;
                    }
                }

                if(isTop)
                {
                    Console.Write(arr[i] + " ");
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.StringExplosion._7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int explosion = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (explosion > 0 && input[i] != '>')
                {
                    input = input.Remove(i, 1); 
                    explosion--; 
                    i--;
                }
                else if (input[i] == '>')
                {
                    explosion += int.Parse(input[i + 1].ToString()); 
                }
            }
            Console.WriteLine(input); ;
        }
    }
}

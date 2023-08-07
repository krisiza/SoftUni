using System;
using System.Collections.Generic;

namespace _1.CountCharsinaString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach (char c in input)
            {
                if (dic.ContainsKey(c))
                {
                    dic[c]++;
                }
                else if(!dic.ContainsKey(c) && c != ' ')
                {
                    dic.Add(c, 1);
                }
            }

            foreach (var c in dic) 
            {
                Console.WriteLine($"{c.Key} -> {c.Value}");            
            }
        }
    }
}

using System;
using System.Linq;

namespace _1.ExtractPersonInformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string name = input.Split('@')[1].Split('|')[0];
                string age = input.Split('#')[1].Split('*')[0];
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}

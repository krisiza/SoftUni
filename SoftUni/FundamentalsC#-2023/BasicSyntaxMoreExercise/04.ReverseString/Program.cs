using System;

namespace _04.ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string reverses = "";

            for(int i = input.Length - 1; i >= 0; i--) 
            {
                reverses += input[i];
            }
            Console.WriteLine(reverses);
        }
    }
}

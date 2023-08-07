using System;
using System.Reflection;

namespace _09.PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                Console.WriteLine(GetPalindromeIntiger(input).ToString().ToLower());
                input = Console.ReadLine();
            }
        }
        private static bool GetPalindromeIntiger(string input)
        {
            string index = "";

            for (int i = input.Length - 1; i >= 0; i--)
            {
                index += input[i];
            }

            if (index == input)
                return true;
            else
                return false;
        }
    }
}

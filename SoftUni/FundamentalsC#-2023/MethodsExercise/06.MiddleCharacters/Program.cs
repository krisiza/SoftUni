using System;

namespace _06.MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Console.WriteLine(GetMiddleChar(input));
        }
        private static string GetMiddleChar(string input)
        {
            bool twoChar = false;
            string middleChar = "";

            if (input.Length % 2 == 0)
                twoChar = true;

            int middIndex = input.Length / 2;

            if (twoChar)
                middleChar = input[middIndex-1].ToString() + input[middIndex].ToString();
            else
                middleChar = input[middIndex].ToString();

            return middleChar;
        }
    }
}

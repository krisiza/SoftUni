using System;

namespace _5.Digits_LettersandOthers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string digits = "";
            string letters = "";
            string characters = "";
            for(int i = 0; i < input.Length; i++) 
            {
                if (char.IsDigit(input[i]))
                {
                    digits+= input[i];
                }
                else if (char.IsLetter(input[i])) 
                {
                    letters+= input[i];
                }
                else
                {
                    characters+= input[i];
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(characters);
        }
    }
}

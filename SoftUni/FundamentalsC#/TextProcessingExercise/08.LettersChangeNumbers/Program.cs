using System;

namespace _08.LettersChangeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sequence = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double result = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                string numbers = sequence[i];

                char firstLetter = numbers[0];
                char secondLetter = numbers[numbers.Length-1];
                int number = FindNumber(numbers);
                


                if(LetterIsUpperCase(firstLetter)) 
                    result += number / LetterPosition(firstLetter);
                else
                    result += number * LetterPosition(firstLetter);

                if (LetterIsUpperCase(secondLetter)) 
                    result -= LetterPosition(secondLetter);
                else
                    result += LetterPosition(secondLetter);

            }

            Console.WriteLine($"{result:f2}");
        }
        static bool LetterIsUpperCase(char c)
        {
            if (char.IsUpper(c)) return true;
            else return false;
        }
        static double LetterPosition(char c)
        {
            if (LetterIsUpperCase(c))
            {
                return c - 'A' + 1;
            }
            else
                return c - 'a' + 1;
        }
        static int FindNumber(string number)
        {
            string num = string.Empty;
            foreach (char c in number)
            {
                if (char.IsDigit(c))
                {
                    num += c;
                }
            }

            return int.Parse(num);
        }

    }
}

using System;

namespace _03.StreamOfLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int counter = 0;
            int counterN = 0;
            int counterC = 0;
            int counterO = 0;

            string word = "";

            char char1 = '-';
            while (input != "End")
            {
                char1 = char.Parse(input);

                switch (char1)
                {
                    case 'n':
                        counterN++;
                        if (counterN == 1)
                            counter++;
                        break;
                    case 'o':
                        counterO++;
                        if (counterO == 1)
                            counter++;
                        break;
                    case 'c':
                        counterC++;
                        if (counterC == 1)
                            counter++;
                        break;
                }
                if (counter == 3)
                {
                    Console.Write(word);
                    Console.Write(" ");
                    word = "";
                    counter = 0;
                    counterN = 0;
                    counterC = 0;
                    counterO = 0;
                }
                if (Char.IsLetter(char1) && char1 != 'n' && char1 != 'o' && char1 != 'c')
                    word += input;

                if (char1 == 'n' && counterN > 1)
                    word += input;
                if (char1 == 'o' && counterO > 1)
                    word += input;
                if (char1 == 'c' && counterC > 1)
                    word += input;

                input = Console.ReadLine();
            }
        }
    }
}

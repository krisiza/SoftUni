using System;

namespace _06.BalancedBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            int counterL = 0;
            int counterR = 0;
            bool openingB = false;
            bool balanced = false;
            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();

                if (input == "(")
                {
                    counterL++;
                    openingB = true;
                }
                if (input == ")")
                {
                    counterR++;
                    openingB = false;
                }

                if (counterR == counterL)
                    balanced = true;
                else if (counterL == counterR)
                    balanced = true;
                else
                    balanced = false;

            }

            if (balanced && openingB == false)
                Console.WriteLine("BALANCED");
            else
                Console.WriteLine("UNBALANCED");
        }
    }
}

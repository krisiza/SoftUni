using System;

namespace _02.LettersCombinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char passLetter = char.Parse(Console.ReadLine());

            int counter = 0;
            for (int i = start; i <= end; i++)
            {
                if (((char)i) != passLetter)
                {
                    for (int y = start; y <= end; y++)
                    {
                        if (((char)y) != passLetter)
                        {
                            for (int j = start; j <= end; j++)
                            {
                                if (((char)j) != passLetter)
                                {
                                    counter++;
                                    Console.Write($"{((char)i)}{((char)y)}{((char)j)} ");
                                }
                            }
                        }
                    }
                }
            }
            Console.Write(counter);
        }
    }
}

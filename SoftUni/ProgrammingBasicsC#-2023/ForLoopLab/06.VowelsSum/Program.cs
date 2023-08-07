using System;

namespace _06.VowelsSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int n = 0;
            int result = 0;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] == 'a')
                    n = 1;
                else if (input[i] == 'e')
                    n = 2;
                else if (input[i] == 'i')
                    n = 3;
                else if (input[i] == 'o')
                    n = 4;
                else if (input[i] == 'u')
                    n = 5;
                else
                    n = 0;

                result += n;

            }

            Console.WriteLine(result);
        }
    }
}

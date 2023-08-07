using System;

namespace _04RefactoringPrimeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 2; i <= number; i++)
            {
                bool primeNumber = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        primeNumber = false;
                        break;
                    }
                }

                if (primeNumber)
                    Console.WriteLine($"{i} -> true");
                else
                    Console.WriteLine($"{i} -> false");
            }

        }
    }
}

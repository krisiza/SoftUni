using System;

namespace _03.SumPrimeNonPrime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isPrime = true;
            int prime = 0;
            int nonPrime = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "stop")
                    break;
                int num = int.Parse(input);

                if (num < 0)
                    Console.WriteLine("Number is negative.");

                for (int i = 1; i <= num; i++)
                {
                    if (i != num && i != 1 && num % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    else
                        isPrime = true;

                }
                if (isPrime && num > 0)
                    prime += num;
                else if (!isPrime && num > 0)
                    nonPrime += num;

            }
            Console.WriteLine($"Sum of all prime numbers is: {prime}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrime}");
        }
    }
}

using System;

namespace _09.House
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            int stars = 0;
            if (n % 2 == 0)
            {
                stars = 2;
            }
            else
            {
                stars = 1;
            }

            int roof = (n + 1) / 2;
            int intervalEven = (n - 1) / 2;
            int intervalOdd = n / 2;
            int intervalEven2 = (n - 1) / 2;
            int intervalOdd2 = n / 2;

            for (int col = stars; col <= n; col += 2)
            {
                if (n % 2 == 0)
                {
                    Console.Write(new String('-', (intervalEven)));
                    intervalEven--;
                }
                else
                {
                    Console.Write(new String('-', (intervalOdd)));
                    intervalOdd--;
                }

                Console.Write(new String('*', col));

                if (n % 2 == 0)
                {
                    Console.Write(new String('-', (intervalEven2)));
                    intervalEven2--;
                }
                else
                {
                    Console.Write(new String('-', (intervalOdd2)));
                    intervalOdd2--;
                }
                Console.WriteLine();
            }

            for (int rows = 1; rows <= n / 2; rows++)
            {
                Console.Write("|");

                if (n > 2)
                {
                    for (int col = 1; col <= n - 2; col++)
                    {
                        Console.Write("*");
                    }
                }

                Console.Write("|");

                Console.WriteLine();
            }
        }
    }
}

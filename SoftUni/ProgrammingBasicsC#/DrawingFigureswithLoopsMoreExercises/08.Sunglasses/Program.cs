using System;

namespace _08.Sunglasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.Write(new String('*', n * 2));
            Console.Write(new String(' ', n));
            Console.Write(new String('*', n * 2));

            Console.WriteLine();
            int num = n / 2;
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write("*");
                for (int j = 0; j < (n * 2) - 2; j++)
                {
                    Console.Write("/");
                }
                Console.Write("*");
                for (int interval = 0; interval < n; interval++)
                {
                    if (n % 2 == 1)
                    {
                        if (i == num - 1)
                            Console.Write("|");
                        else
                            Console.Write(" ");
                    }
                    if (n % 2 == 0)
                    {
                        if (i == num - 2)
                            Console.Write("|");
                        else
                            Console.Write(" ");
                    }
                }
                Console.Write("*");
                for (int j = 0; j < (n * 2) - 2; j++)
                {
                    Console.Write("/");
                }
                Console.Write("*");

                Console.WriteLine();
            }

            Console.Write(new String('*', n * 2));
            Console.Write(new String(' ', n));
            Console.Write(new String('*', n * 2));
        }
    }
}

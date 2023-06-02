using System;

namespace _10.Diamond
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int interval = 1;

            if (n % 2 == 0)
            {
                Console.Write(new String('-', (n - 1) / 2));
                Console.Write("**");
                Console.Write(new String('-', (n - 1) / 2));
            }
            else
            {
                Console.Write(new String('-', n / 2));
                Console.Write("*");
                Console.Write(new String('-', n / 2));
            }

            Console.WriteLine();
            if (n % 2 == 0)
            {
                interval = 2;
                for (int i = n / 2 - 2; i >= 0; i--)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write('-');
                    }
                    Console.Write('*');
                    Console.Write(new String('-', interval));
                    Console.Write('*');
                    interval += 2;
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write('-');
                    }
                    Console.WriteLine();
                }
                interval -= 4;
                for (int i = 1; i <= n / 2 - 2; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write('-');
                    }
                    Console.Write('*');
                    Console.Write(new String('-', interval));
                    Console.Write('*');
                    interval -= 2;
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write('-');
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = n / 2 - 1; i >= 0; i--)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write('-');
                    }
                    Console.Write('*');
                    Console.Write(new String('-', interval));
                    Console.Write('*');
                    interval += 2;
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write('-');
                    }
                    Console.WriteLine();
                }
                interval -= 4;
                for (int i = 1; i <= n / 2 - 1; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write('-');
                    }
                    Console.Write('*');
                    Console.Write(new String('-', interval));
                    Console.Write('*');
                    interval -= 2;
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write('-');
                    }
                    Console.WriteLine();
                }
            }

            if (n > 2)
            {
                if (n % 2 == 0)
                {
                    Console.Write(new String('-', (n - 1) / 2));
                    Console.Write("**");
                    Console.Write(new String('-', (n - 1) / 2));
                }
                else
                {
                    Console.Write(new String('-', n / 2));
                    Console.Write("*");
                    Console.Write(new String('-', n / 2));
                }
            }
        }
    }
}

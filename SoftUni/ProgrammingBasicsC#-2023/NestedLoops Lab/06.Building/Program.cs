using System;

namespace _06.Building
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stock = int.Parse(Console.ReadLine());
            int room = int.Parse(Console.ReadLine());

            for (int i = stock; i >= 1; i--)
            {
                for (int y = 0; y < room; y++)
                {
                    if (i == stock)
                        Console.Write("L" + i);
                    else if (i % 2 == 1)
                        Console.Write("A" + i);
                    else if (i % 2 == 0)
                        Console.Write("O" + i);

                    Console.Write(y + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

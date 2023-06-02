using System;

namespace _04.CarNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            bool even = false;
            int sum = 0;
            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 0)
                    even = true;
                else
                    even = false;
                for (int y = start; y <= end; y++)
                {
                    for (int j = start; j <= end; j++)
                    {
                        sum = y + j;
                        if (sum % 2 == 0)
                        {
                            for (int k = start; k <= end; k++)
                            {
                                if (even && k % 2 == 1 && i > k)
                                {
                                    Console.Write($"{i}{y}{j}{k} ");
                                }
                                else if (!even && k % 2 == 0 && i > k)
                                {
                                    Console.Write($"{i}{y}{j}{k} ");
                                }
                            }
                        }
                        else
                            sum = 0;

                    }
                }
            }
        }
    }
}

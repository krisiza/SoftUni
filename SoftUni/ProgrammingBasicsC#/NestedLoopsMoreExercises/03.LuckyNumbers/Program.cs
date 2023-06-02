using System;

namespace _03.LuckyNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum1 = 0;
            int sum2 = 0;
            for (int i = 1; i <= 9; i++)
            {

                for (int y = 1; y <= 9; y++)
                {
                    sum1 = i + y;
                    if (n % sum1 == 0)
                    {
                        for (int j = 1; j <= 9; j++)
                        {
                            for (int k = 1; k <= 9; k++)
                            {
                                sum2 += j + k;
                                if (sum1 == sum2 && n % sum2 == 0)
                                {
                                    Console.Write($"{i}{y}{j}{k} ");
                                }
                                else
                                {
                                    sum2 = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        sum1 = 0;
                    }
                }
            }
        }
    }
}

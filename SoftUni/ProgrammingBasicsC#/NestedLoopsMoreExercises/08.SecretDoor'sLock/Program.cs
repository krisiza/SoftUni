using System;

namespace _08.SecretDoor_sLock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            bool numIsPrime = false;
            for (int i = 1; i <= num1; i++)
            {
                if (i % 2 == 0)
                {
                    for (int y = 2; y <= num2; y++)
                    {
                        for (int k = 1; k < y; k++)
                        {
                            if (k != y && k != 1 && y % k == 0)
                            {
                                numIsPrime = false;
                                break;
                            }
                            else
                            {
                                numIsPrime = true;
                                continue;
                            }
                        }
                        if (numIsPrime)
                        {
                            for (int j = 1; j <= num3; j++)
                            {
                                if (j % 2 == 0)
                                {
                                    Console.WriteLine($"{i} {y} {j}");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

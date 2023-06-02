using System;

namespace _01.UniquePINCodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumEnd = int.Parse(Console.ReadLine());
            int secondNumEnd = int.Parse(Console.ReadLine());
            int thirdNumEnd = int.Parse(Console.ReadLine());

            string output = "";
            bool prime = true;



            for (int i = 1; i <= firstNumEnd; i++)
            {
                if (i % 2 == 0)
                {

                    for (int y = 2; y <= secondNumEnd; y++)
                    {
                        for (int k = 1; k < y; k++)
                        {
                            if (k != y && k != 1 && y % k == 0)
                            {
                                prime = false;
                                break;
                            }
                            else
                            {
                                prime = true;
                                continue;
                            }
                        }

                        if (prime)
                        {
                            for (int j = 1; j <= thirdNumEnd; j++)
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

using System;

namespace _05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordNum = "";
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 9; i++)
            {

                for (int y = 1; y < 9; y++)
                {
                    for (int k = 1; k < 9; k++)
                    {
                        for (int j = 1; j < 9; j++)
                        {
                            if (n % i == 0)
                            {
                                wordNum += i.ToString();
                            }
                            if (n % y == 0)
                            {
                                wordNum += y.ToString();
                            }
                            if (n % k == 0)
                            {
                                wordNum += k.ToString();
                            }
                            if (n % j == 0)
                            {
                                wordNum += j.ToString();
                            }

                            if (wordNum.Length == 4)
                                Console.Write(wordNum + " ");
                            wordNum = "";
                        }
                    }
                }
            }
            Console.WriteLine(wordNum);
        }
    }
}

using System;

namespace _02.EqualSumsEvenOdd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            for (int i = num1; i <= num2; i++)
            {
                string currentNum = i.ToString();
                int sum1 = 0;
                int sum2 = 0;
                for (int y = 0; y < currentNum.Length; y++)
                {
                    int currentDigit = int.Parse(currentNum[y].ToString());
                    if (y % 2 == 0)
                        sum1 += currentDigit;
                    else
                        sum2 += currentDigit;

                }
                if (sum1 == sum2)
                    Console.Write(i + " ");
            }
        }
    }
}

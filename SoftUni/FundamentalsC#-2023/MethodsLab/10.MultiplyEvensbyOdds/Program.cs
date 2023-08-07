using System;

namespace _10.MultiplyEvensbyOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

           Console.WriteLine(GetMultipleOfEvenAndOdds(GetMultipleOfEvenDigits(input), GetSumOfOddDigits(input)));
        }
        static int GetMultipleOfEvenDigits(int input)
        {
            string indexToString = Math.Abs(input).ToString();
            int sum = 0;
            int index = 0;

            for(int i =0; i < indexToString.Length; i++) 
            {
                index = Convert.ToInt32(indexToString[i] - '0');
                if (index % 2 == 0)
                {
                    sum += Convert.ToInt32(index);
                }
            }

            return sum;
            
        }

        static int GetSumOfOddDigits(int input)
        {
            string indexToString = Math.Abs(input).ToString();
            int sum = 0;
            int index = 0;

            for (int i = 0; i < indexToString.Length; i++)
            {
                index = Convert.ToInt32(indexToString[i] - '0');
                if (index % 2 == 1)
                {
                    sum += Convert.ToInt32(index);
                }
            }

            return sum;
        }
        static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            return evenSum * oddSum;
        }
    }

}

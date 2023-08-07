using System;

namespace _10.TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            GetTopIntiger(n);
        }
        private static void GetTopIntiger(int n)
        {

            for (int j = 1; j < n; j++)
            {
                int sum = 0;
                bool oddDigit = false;
                string input = j.ToString();

                for (int i = 0; i < input.Length; i++)
                {
                    sum += Convert.ToInt32(input[i] - '0');
                    int digit = Convert.ToInt32(input[i] - '0');
                    if (digit % 2 == 1)
                    {
                        oddDigit = true;
                    }
  
                }

                if (sum % 8 == 0 && oddDigit)
                {
                    Console.WriteLine(j);
                }
            }


        }
    }
}

using System;
using System.Numerics;
using System.Text;

namespace _05.MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string bigNumber = Console.ReadLine();
            int digit = int.Parse(Console.ReadLine());

            if (digit == 0)
            {
                Console.WriteLine("0");
                return;
            }
            int rest = 0;
            for (int i = bigNumber.Length - 1; i >= 0; i--)
            {
                int num = (int)bigNumber[i] - 48;

                int result = num * digit;

                result += rest;
                rest = 0;

                if (result > 9)
                {
                    int lastdigit = result % 10;
                    rest = result / 10;

                    sb.Append(lastdigit);
                }
                else
                    sb.Append(result);
            }
            if (rest > 0)
                sb.Append(rest);

            for (int i = sb.Length - 1; i >= 0; i--)
            {
                Console.Write(sb[i]);
            }

        }
    }
}

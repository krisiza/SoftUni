using System;

namespace _2.SumDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            string numberString = num.ToString();
            int sum = 0;

            for(int i = 0; i < numberString.Length; i++) 
            {
                sum += int.Parse(numberString[i].ToString());
            }

            Console.WriteLine(sum);
        }
    }
}

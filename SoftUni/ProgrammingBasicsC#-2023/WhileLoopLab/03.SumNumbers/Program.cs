using System;

namespace _03.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            bool corr = false;
            do
            {
                int num3 = int.Parse(Console.ReadLine());
                sum = sum + num3;
                if (sum >= num)
                    corr = true;

            }
            while (!corr);
            Console.WriteLine(sum);
        }
    }
}

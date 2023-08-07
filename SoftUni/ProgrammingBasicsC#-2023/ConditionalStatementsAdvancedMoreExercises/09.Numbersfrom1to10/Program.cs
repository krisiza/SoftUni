using System;

namespace _09.Numbersfrom1to10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = 1;

            do
            {
                Console.WriteLine(num);
                num++;
            }
            while (num <= 10);
        }
    }
}

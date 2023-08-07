using System;

namespace _04.EvenPowersof2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int result = 0;
            for (int i = 0; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    result = (int)Math.Pow(2, i);
                    Console.WriteLine(result);
                }

            }
        }
    }
}

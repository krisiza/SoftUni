using System;

namespace _04.Sequence2k_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool c = false;
            int n2 = 1;
            do
            {
                Console.WriteLine(n2);
                n2 = n2 * 2 + 1;
                if (n2 > n)
                    c = true;
            }
            while (!c);
        }
    }
}

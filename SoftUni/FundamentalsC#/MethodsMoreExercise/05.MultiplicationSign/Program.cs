using System;

namespace _05.MultiplicationSign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());

            DefiniteResult(n1, n2, n3);
        }
        static void DefiniteResult(int n, int n2, int n3)
        {
            if (n < 0 && n2 > 0 && n3 > 0 || n2 < 0 && n > 0 && n3 > 0 || n3 < 0 && n >0 && n2 > 0 || n < 0 && n2 <0 && n3 < 0)
                Console.WriteLine("negative");
            else if
                (n == 0 || n2 == 0 || n3 == 0)
                Console.WriteLine("zero");
            else
                Console.WriteLine("positive");
        }
    }
}

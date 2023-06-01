using System;
using System.Reflection.PortableExecutable;

namespace _1.Sort_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            Console.WriteLine(Math.Max(num1, Math.Max(num2, num3)));
            if (num1 >= num2 && num1 <= num3 || num1 <= num2 && num1 >= num3)
                Console.WriteLine(num1);
            else if (num2 >= num1 && num2 <= num3 || num2 <= num1 && num2 >= num3)
                Console.WriteLine(num2);
            else if (num3 >= num2 && num3 <= num1 || num3 <= num2 && num3 >= num1)
                Console.WriteLine(num3);
            Console.WriteLine(Math.Min(num1,Math.Min(num2, num3)));
        }
    }
}

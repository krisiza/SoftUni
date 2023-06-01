using System;

namespace _10.LowerorUpper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());

            bool isUpper = Char.IsUpper(a);

            if (isUpper)
                Console.WriteLine("upper-case");
            else
                Console.WriteLine("lower-case");
        }
    }
}

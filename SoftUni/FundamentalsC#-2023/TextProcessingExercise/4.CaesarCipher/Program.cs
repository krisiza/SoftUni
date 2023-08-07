using System;
using System.Collections.Generic;
using System.Text;

namespace _4.CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                int index = input[i];
                output.Append((char)(index + 3));
            }
            Console.Write(output);
        }
    }
}

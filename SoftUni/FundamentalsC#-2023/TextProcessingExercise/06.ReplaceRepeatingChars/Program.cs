using System;
using System.Linq;
using System.Text;

namespace _06.ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            char index = input[0];
            sb.Append(index);

            for (int i = 1; i < input.Length; i++)
            {
                if (index != input[i])
                {
                    index = input[i];
                    sb.Append(index);
                }
            }

            Console.WriteLine(sb);
        }
    }
}

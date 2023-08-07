using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.TreasureFinder
{
    /*
1 2 1 3
ikegfp'jpne)bv=41P83X@
ujfufKt)Tkmyft'duEprsfjqbvfv=53V55XA
find
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Dictionary<string, string> coordinates = new Dictionary<string, string>();

            string input = Console.ReadLine();

            while (input != "find")
            {
                string output = string.Empty;
                int j = 0;
                string type = string.Empty;
                for (int i = 0; i < input.Length; i++)
                {
                    if (j >= numbers.Length)
                        j = 0;

                    int index = input[i] - numbers[j];
                    char c = (char)index;

                    output += c;
                    j++;
                }

                int startIndex = output.IndexOf('&');
                int endIndex = output.LastIndexOf('&');
                type = output.Substring(startIndex + 1, (endIndex - startIndex) -1);
                coordinates[type] = "1";

                startIndex = output.IndexOf('<');
                endIndex = output.IndexOf('>');
                output = output.Substring(startIndex + 1, (endIndex - startIndex) -1);
                coordinates[type] = output;

                input = Console.ReadLine();
            }
            
            foreach(var str in coordinates)
            {
                Console.WriteLine($"Found {str.Key} at {str.Value}");
            }
        }
    }
}

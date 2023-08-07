using System;

namespace _3.ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] path = Console.ReadLine().Split('\\');
            string[] output = path[path.Length - 1].Split('.');

            Console.WriteLine($"File name: {output[0]}\nFile extension: {output[1]}");
        }
    }
}

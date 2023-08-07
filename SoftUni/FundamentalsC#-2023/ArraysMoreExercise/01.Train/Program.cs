using System;

namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] passingers = new int[n];
            int sum = 0;
            for (int i = 0; i < passingers.Length; i++) 
            {
                int pass = int.Parse(Console.ReadLine());
                passingers[i] = pass;
                sum += pass;
            }
            
            Console.WriteLine(string.Join(" ", passingers));
            Console.WriteLine(sum);
        }
    }
}

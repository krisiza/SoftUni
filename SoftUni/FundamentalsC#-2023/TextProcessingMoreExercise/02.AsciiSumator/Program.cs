using System;

namespace _02.AsciiSumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());   
            string phrase = Console.ReadLine();

            int sum = 0;
            for(int i = 0; i < phrase.Length; i++) 
            {
                if (phrase[i] > first && phrase[i] < second) 
                {
                    sum += phrase[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
